using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fly.Entities
{
    public abstract class Person
    {
        [Key]
        public int PersonID { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string Adresse { get; set; }
    }
}
