using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAPIAuth.Model
{
    public enum EsitoSMS
    {
        //Status Value
        NonDefinito = 0,
        WAITING = 1,//	“WAITING” ATTESA
        SENT_TO_SMSC = 2,// SENT_TO_SMSC = 0,//	“SENT” INVIATO 
        WAIT4DLVR = 3, //WAITING_DELIVERY = 0,//	“WAIT4DLVR”   IN ATTESA DI CONSEGNA
        SENT = 4,//	“SENT”  SPEDITO
        DLVRD = 5,//DELIVERY_RECEIVED = 0,//“DLVRD” "SPEDITO CONSEGNA RICEVUTA"
        TOOM4USER  = 6, //TOO_MANY_SMS_FROM_USER = 0,//	“TOOM4USER”  TROPPI SMS DA UTENTE
        TOOM4NUM = 7, //TOO_MANY_SMS_FOR_NUMBER = 0,//“TOOM4NUM”    TROPPI SMS per numero telefonico 
        ERROR = 8,//	“ERROR”
        TIMEOUT = 9,//	“TIMEOUT”
        UNKNRCPT = 10,// UNPARSABLE_RCPT = 0,//	“UNKNRCPT”    PREFISSO SCONOSCIUTO
        UNKNPFX = 11,// UNKNOWN_PREFIX = 0,//“UNKNPFX”          PREFISSO SCONOSCIUTO
        DEMO = 12,// SENT_IN_DEMO_MODE = 0,//	“DEMO”
        SCHEDULED = 13,// WAITING_DELAYED = 0,//“SCHEDULED”    ATTESA RITARDATA  = 0,   "PIANIFICATO"
        INVALIDDST = 14,// INVALID_DESTINATION = 0,//	“INVALIDDST”
        BLACKLISTED = 15,//NUMBER_BLACKLISTED = 0,//“BLACKLISTED”
        NUMBER_USER_BLACKLISTED = 16,//NUMBER_USER_BLACKLISTED = 0,//	“BLACKLISTED”
        SMSC_REJECTED = 17,//	“KO”
        INVALID_CONTENTS = 18,//“INVALIDCONTENTS”
    }

    // TODO: Ricercare e censire gli stati
    public enum EsitoSMSSmsSender
    {
        //Status Value
        WAITING = 3,
        DELIVERED = 5,
        ERROR = 8, 
    }


    public enum EsitoSMSSmsHosting
    {
        INSERTED = 3,
        DELIVERED = 5,
        ERROR = 8,
    }
}
