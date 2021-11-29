using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiAuth.Models
{
    public class Smscl01
    {
     
        [Required]
        public long Id { get; set; }
        [Required]
        public int Regrdl { get; set; }        
        public Guid Token { get; set; }          
        public string TipologiaSMS { get; set; }
        [Required]
        public string DestSMS { get; set; }     
        [Required]
        public string CorpoSMS { get; set; }    
        [Required]
        public string Utente { get; set; }      
        public string Sistema { get; set; }        
        public string Cliente { get; set; }
        public string CentroCosto { get; set; }
        public string AreaBusiness { get; set; }
        public int Esito { get; set; }
        public int TipoInvio { get; set; }
        public int QualitaInvio { get; set; }
        public int NrInvio { get; set; }
        public int Stato { get; set; }

        //public string IdUtente { get; set; }
        //[Required]
        //[StringLength(3999, MinimumLength = 1, ErrorMessage = "è necessario specificare un testo compreso tra 1 e 3999 caratteri.")]

        public bool IsReceived { get; set; }

        //public DateTime DataOraUpDate { get; set; }
        //public DateTime DataOraUltimoPut { get; set; }
        //public bool IsReceived { get; set; }
    }
}
