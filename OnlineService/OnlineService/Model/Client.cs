using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineService.Model
{
    internal class Client
    {
        [Key]
        public int IdClient { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public virtual Projet projet { get; set; }
    }
}
