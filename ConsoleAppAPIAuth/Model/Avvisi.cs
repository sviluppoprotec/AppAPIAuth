using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAPIAuth.Model
{
    public class Avvisi
    {
        public int id { get; set; }
        public string ID_SMS { get; set; }
        
        public string telefoniDestinatari { get; set; }

        public string CORPOSMS { get; set; }

        public int QualitaInvio { get; set; }
        public SMSStatus status { get; set; } // nome dell'tente dellapplicativo
        //RispostaInvio =SMSAruba.GestioneSMS(telefoniDestinatari: APISms.DESTSMS, SMSAruba.MESSAGE_HIGH_QUALITY, Messaggio: APISms.CORPOSMS);
    }
}
