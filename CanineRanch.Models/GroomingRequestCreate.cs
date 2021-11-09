using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CanineRanch.Models
{
    public class GroomingRequestCreate
    {
        public int ClientID { get; set; }
        public SelectList LastName { get; set; }
        public int DogID { get; set; }
        public SelectList DogNames { get; set; }
        public int GroomFrequency { get; set; }
        public bool FirstTimeGroom { get; set; }
        public DateTime RequestTimeStamp {get; set;}
    }
}
