using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanineRanch.Models
{
    public class GroomingRequestCreate
    {
        public string DogName { get; set; }
        public int GroomFrequescy { get; set; }
        public bool FirstTimeGroom { get; set; }
    }
}
