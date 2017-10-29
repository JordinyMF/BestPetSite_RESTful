using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace BestPetSite.Models
{

    [Table("[CustomerDetails]")]
   public class CustomerDetail
    {
        public int IdCustomer { get; set; }
        public DateTime MinimumAttentionDate { get; set;}
        public DateTime MaximunAttentionDate { get; set;}
        public TimeSpan MinimumAttentionHour { get; set;}
        public TimeSpan MaximunAttentionHour { get; set;}
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Description { get; set; }
    }
}
