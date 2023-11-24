using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineService.Model
{
    internal class Projet
    {
        [Key]
        public int IdProjet { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Budget { get; set; }
        public virtual Client client { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
