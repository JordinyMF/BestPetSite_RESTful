﻿using System;
using Dapper.Contrib.Extensions;

namespace BestPetSite.Models
{
    [Table("[Users]")]
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Status { get; set; }
    }
}
