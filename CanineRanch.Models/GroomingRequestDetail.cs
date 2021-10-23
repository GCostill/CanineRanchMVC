using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanineRanch.Models
{
    class GroomingRequestDetail
    {
        public int RequestID { get; set; }
        public string DogName { get; set; }
        public DateTime RequestTimeStamp { get; set; }
        public int GroomFrequency { get; set; }
        public bool FirstTimeGroom { get; set; }
    }
}
