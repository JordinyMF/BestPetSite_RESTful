using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace BestPetSite.Models
{

    [Table("[TypesPetControl]")]
    public class TypePetControl
    {
        public int Id { get; set; }
        public int IdPet { get; set; }
        public string Description { get; set; }
        public DateTime AttentionDate { get; set;}
        public TimeSpan AttentionHour { get; set;}
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }

    }
}
