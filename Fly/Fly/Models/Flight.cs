﻿using Fly.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        public DateTime Date { get; set; }
        public string Depart { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public double occupation { get; set; }
        public virtual Pilot Pilot { get; set; }
        public virtual Airline Airline { get; set; }
        public virtual Passenger Passenger { get; set; }
       
    }
}
