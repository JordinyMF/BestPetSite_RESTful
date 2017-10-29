using System;
using Dapper.Contrib.Extensions;


namespace BestPetSite.Models
{
    [Table("[Customers]")]
   public class Customer
    {
        public int Id { get; set; }
        public int IdCustomerType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Direction { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool Status { get; set; }
    }
}
