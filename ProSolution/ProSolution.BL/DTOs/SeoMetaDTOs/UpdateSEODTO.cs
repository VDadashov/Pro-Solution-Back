namespace ProSolution.Business.DTOs.SEODTOs
{
    public class UpdateSEOMetaDTO
    {
        public int Id { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaTitle { get; set; }
         
        public string MetaTags { get; set; }
         
    }
}
