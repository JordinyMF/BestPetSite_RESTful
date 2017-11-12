using System.Collections.Generic;

namespace BestPetSite.WebApi.Models.Dto
{
    public class DataResultDto
    {
        public bool Result { get; set; }
        public ResponseDto Response { get; set; }
        public object Content { get; set; }
    }
}
