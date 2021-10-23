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
        public DateTime RequestTimeStamp { get; set; }
        public int GroomFrequency { get; set; }
        [Required]
        public bool FirstTimeGroom { get; set; }
        [ForeignKey(nameof(Client))]
        [Required]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(Dog))]
        [Required]
        public int DogID { get; set; }
        public virtual Dog Dog { get; set; }
    }
}
