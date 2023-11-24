using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyAlex.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
    }
}
