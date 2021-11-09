using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CanineRanch.Data
{
    public class Dog
    {
        [Key]
        public int DogID { get; set; }
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string DogName { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        [Required]
        public bool IsFixed { get; set; }
    }
}
