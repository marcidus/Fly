using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Paiement
    {
        [Key]
        public int PaiementId { get; set; }
        public string Devise { get; set; }
        public float Montant { get; set; }
        
    }
}
