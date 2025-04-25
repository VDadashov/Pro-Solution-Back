    using MailKit.Net.Smtp;
    using MailKit.Security;
    using MimeKit;
    using Microsoft.Extensions.Options;
using ProSolution.BL.Settings;
using ProSolution.BL.DTOs.ContactMessageDTOs;
    using ProSolution.BL.Services.InternalServices.Abstractions;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace ProSolution.BL.Services.InternalServices.Implementations
{

    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendContactMessageAsync(ContactMessageDTO contactDto)
        {
            // Письмо суперадмину
            var adminMessage = new MimeMessage();
            //adminMessage.From.Add(MailboxAddress.Parse(_smtpSettings.Username));
            adminMessage.From.Add(new MailboxAddress("ProSolution", _smtpSettings.Username));
            adminMessage.To.Add(MailboxAddress.Parse(_smtpSettings.AdminEmail));
            adminMessage.Subject = "📩Veb saytdan yeni mesaj daxil olub:";

            adminMessage.Body = new TextPart("html")
            {
                Text = $@"
                <h3>Əlaqə məlumatları:</h3>
                <p><strong>Ad:</strong> {contactDto.FirstName}</p>
                <p><strong>Soyad:</strong> {contactDto.LastName}</p>
                <p><strong>📧 E-poçt:</strong> {contactDto.Email}</p>
                <p><strong>📞 Telefon:</strong> {contactDto.PhoneNumber}</p>
                <p><strong>📨 Mesaj:</strong><br/>{contactDto.Message}</p>
            "
            };

            // Письмо пользователю
            var userMessage = new MimeMessage();
            userMessage.From.Add(new MailboxAddress("ProSolution", _smtpSettings.Username));


            userMessage.To.Add(MailboxAddress.Parse(contactDto.Email));
            userMessage.Subject = "✅ Mesajınız alındı.";

            userMessage.Body = new TextPart("html")
            {
                Text = $@"
                <h3>Salam, {contactDto.FirstName}!</h3>
                <p>Mesajınız alındı.</p>
                <p>Bizə müraciət etdiyiniz üçün təşəkkür edirik.</p>
                <p>Tezliklə sizinlə əlaqə saxlayacağıq.</p>
                <br/>
                <p>Hörmətlə,<br/>ProSolution komandasi</p>
            "
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);

            await smtp.SendAsync(adminMessage);
            await smtp.SendAsync(userMessage);

            await smtp.DisconnectAsync(true);
        }

    }


}
