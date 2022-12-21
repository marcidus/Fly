using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Baggage
    {
        [Key]
        public int BaggageId { get; set; }
        public float baggageWeight { get; set; }
        public float BaggageSizer { get; set; }

    }
}
