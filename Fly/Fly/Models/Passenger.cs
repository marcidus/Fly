﻿using Fly.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Passenger : Person
    {
       
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<Baggage> Baggages { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
