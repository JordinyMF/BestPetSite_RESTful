namespace BestPetSite.WebApi.Models.Dto
{
    public class ErrorDto
    {
        public int Code { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}