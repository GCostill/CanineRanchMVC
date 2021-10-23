using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanineRanch.Models
{
    class DogDetail
    {
        public int DogID { get; set; }
        public string DogName { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public bool IsFixed { get; set; }
    }
}
