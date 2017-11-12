using System.Collections.Generic;

namespace BestPetSite.WebApi.Models.Dto
{
    public class ResponseDto
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public List<ErrorDto> Errors { get; set; }
    }
}