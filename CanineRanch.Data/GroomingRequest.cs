using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanineRanch.Data
{
    public class GroomingRequest
    {
        [Key]
        public int RequestID { get; set; }
        public Guid ID { get; set; }
        public DateTime RequestTimeStamp { get; set; }
        public int GroomFrequency { get; set; }
        [Required]
        public bool FirstTimeGroom { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public int DogID { get; set; }
        public virtual Client Client { get; set; }
        public virtual Dog Dog { get; set; }

        public GroomingRequest()
        {
            RequestTimeStamp = DateTime.Now;
        }
    }
}
