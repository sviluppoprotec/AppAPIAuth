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
        NonDefinito,
        WAITING,//	“WAITING” ATTESA
        SENT_TO_SMSC,//	“SENT” INVIATO 
        WAITING_DELIVERY,//	“WAIT4DLVR”   IN ATTESA DI CONSEGNA
        SENT,//	“SENT”  SPEDITO
        DELIVERY_RECEIVED,//“DLVRD” "SPEDITO CONSEGNA RICEVUTA"
        TOO_MANY_SMS_FROM_USER,//	“TOOM4USER”  TROPPI SMS DA UTENTE
        TOO_MANY_SMS_FOR_NUMBER,//“TOOM4NUM”    TROPPI SMS per numero telefonico 
        ERROR,//	“ERROR”
        TIMEOUT,//	“TIMEOUT”
        UNPARSABLE_RCPT,//	“UNKNRCPT”    PREFISSO SCONOSCIUTO
        UNKNOWN_PREFIX,//“UNKNPFX”          PREFISSO SCONOSCIUTO
        SENT_IN_DEMO_MODE,//	“DEMO”
        WAITING_DELAYED,//“SCHEDULED”    ATTESA RITARDATA ,   "PIANIFICATO"
        INVALID_DESTINATION,//	“INVALIDDST”
        NUMBER_BLACKLISTED,//“BLACKLISTED”
        NUMBER_USER_BLACKLISTED,//	“BLACKLISTED”
        SMSC_REJECTED,//	“KO”
        INVALID_CONTENTS,//“INVALIDCONTENTS”
    }
}
