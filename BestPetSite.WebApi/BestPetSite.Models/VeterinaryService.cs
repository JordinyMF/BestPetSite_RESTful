using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace BestPetSite.Models
{
    [Table("[VeterinaryServices]")]
   public class VeterinaryService
    {
        public int IdCustomer { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set;}
}
}
