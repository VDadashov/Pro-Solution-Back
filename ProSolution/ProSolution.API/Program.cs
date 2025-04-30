using Microsoft.EntityFrameworkCore;
using ProSolution.API.Middlewares;
using ProSolution.BL.Profiles;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Services.InternalServices.Implementations;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions;
using ProSolution.DAL.Repositories.Abstractions.Product;
using ProSolution.DAL.Repositories.Abstractions.ProductImage;
using ProSolution.DAL.Repositories.Abstractions.Slider;
using ProSolution.DAL.Repositories.Implementations;
using ProSolution.DAL.Repositories.Implementations.Product;
using ProSolution.DAL;
using ProSolution.BL;
using ProSolution.BL.Settings;
using Microsoft.Extensions.Options;
using ProSolution.DAL.Repositories.Implementations.ProductImage;
using Microsoft.AspNetCore.Identity;
using ProSolution.BL.Helpers;
using ProSolution.Core.Entities;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using ProSolution.BL.DTOs.SliderDTO;
using ProSolution.BL.DTOs.SliderDTOs;
using CloudinaryDotNet;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSQL")));
builder.Services.AddRepositories();
builder.Services.AddServices(builder.Configuration);
//builder.Services.AddCloud();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<AppSettings>>().Value);
//builder.Services.AddScoped<IAppInfoService, AppInfoService>();

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IAuthService, AuthService>();


//var cloudName = builder.Configuration["Cloudinary:CloudName"];
//var apiKey = builder.Configuration["Cloudinary:ApiKey"];
//var apiSecret = builder.Configuration["Cloudinary:ApiSecret"];

//var cloudinaryAccount = new Account(cloudName, apiKey, apiSecret);
//var cloudinary = new Cloudinary(cloudinaryAccount);

//// Cloudinary servisini qeydiyyatdan keçirt
//builder.Services.AddSingleton(cloudinary);


//add identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();
builder.Services.AddJwt(builder.Configuration);

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddScoped<IRoleCheckerService, RoleCheckerService>();
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
});


builder.Services.AddScoped<ICatagoryReadRepository , CatagoryReadRepository>();
builder.Services.AddScoped<ICatagoryWriteRepository , CatagoryWriteRepository>();
builder.Services.AddScoped<ISliderReadRepository , SliderReadRepository>();
builder.Services.AddScoped<ISliderWriteRepository , SliderWriteRepository>();
builder.Services.AddScoped <IProductReadRepository , ProductReadRepository>();
builder.Services.AddScoped <IProductWriteRepository , ProductWriteRepository>();
builder.Services.AddScoped <IPartnerWriteRepository , PartnerWriteRepository>();
builder.Services.AddScoped <IPartnerReadRepository , PartnerReadRepository>();
builder.Services.AddScoped <IBrandReadRepository , BrandReadRepository>();
builder.Services.AddScoped <IBrandWriteRepository , BrandWriteRepository>();
builder.Services.AddScoped <IProductImageWriteRepository , ProductImageWriteRepository>();
builder.Services.AddScoped <IProductImageReadRepository , ProductImageReadRepository>();




builder.Services.AddAutoMapper(typeof(CatagoryProfile).Assembly);
builder.Services.AddScoped<ICatagoryService , CatagoryService>();
builder.Services.AddScoped<IProductService , ProductService>();
builder.Services.AddScoped<IPartnerService , PartnerService>();
builder.Services.AddScoped<ISliderService , SliderService>();
builder.Services.AddScoped<IBrandService , BrandService>();
builder.Services.AddScoped<IFileManagerService , FileManagerService>();
builder.Services.AddControllers()
    .AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssemblyContaining<SliderCreateDTOValidator>();
        //config.RegisterValidatorsFromAssemblyContaining<SliderUpdateDTOValidator>();
    });


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await ProSolution.DAL.Seed.DbInitializer.SeedAsync(services);
    await RoleSeeder.SeedDefaultUsersAsync(services);

}

//if (app.Environment.IsDevelopment())
//{
//}
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<XssProtectionMiddleware>();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.MapControllers();

app.Run();
