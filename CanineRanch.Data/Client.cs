using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanineRanch.Data
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
