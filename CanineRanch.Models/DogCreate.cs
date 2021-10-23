using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanineRanch.Models
{
    class DogCreate
    {
        public string DogName { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        [Required]
        public bool IsFixed { get; set; }
    }
}
