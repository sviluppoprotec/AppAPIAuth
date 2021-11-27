using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleNotificheAPI
{
    class Classi
    {
    }
    public enum SMSStatus
    {
        WAITING, //	“WAITING”
        SENT_TO_SMSC,   //	“SENT”
        WAITING_DELIVERY,//		“WAIT4DLVR”
        SENT,//		“SENT”
        DELIVERY_RECEIVED,//		“DLVRD”
        TOO_MANY_SMS_FROM_USER,//		“TOOM4USER”
        TOO_MANY_SMS_FOR_NUMBER,//		“TOOM4NUM”
        ERROR,//		“ERROR”
        TIMEOUT,//		“TIMEOUT”
        UNPARSABLE_RCPT,//		“UNKNRCPT”
        UNKNOWN_PREFIX,//		“UNKNPFX”
        SENT_IN_DEMO_MODE,//		“DEMO”
        WAITING_DELAYED,//		“SCHEDULED”
        INVALID_DESTINATION,//		“INVALIDDST”
        NUMBER_BLACKLISTED,//		“BLACKLISTED”
        NUMBER_USER_BLACKLISTED,//		“BLACKLISTED”
        SMSC_REJECTED,  //	“KO”
        INVALID_CONTENTS,	//	“INVALIDCONTENTS”
        //SCHEDULED,  // postponed, not jet arrived
        //SENT,       // sent, wait for delivery notification (depending on message type)
        //DLVRD,      // the sms has been correctly delivered to the mobile phone
        //ERROR,      // error sending sms
        //TIMEOUT,    // cannot deliver sms to the mobile in 48 hours
        //TOOM4NUM,   // too many messages sent to this number (spam warning)
        //TOOM4USER,  // too many messages sent by this user
        //UNKNPFX,    // unknown/unparsable mobile phone prefix
        //UNKNRCPT,   // unknown recipient
        //WAIT4DLVR,  // message sent, waiting for delivery notification
        //WAITING,    // not yet sent (still active)
        //UNKNOWN     // received an unknown status code from server (should never happen!)
    }


    //public enum EsitoInvioMailSMS
    //{
    //    [XafDisplayName("posticipato, non ancora inviato")]
    //    [ImageName("State_Priority_Low")]
    //    SCHEDULED,	// postponed, not jet arrived  //SCHEDULED	// posticipato, non ancora inviato
    //    [XafDisplayName("Consegnato")] //inviato, non attende delivery
    //    [ImageName("State_Priority_Low")]
    //    SENT,		// sent, wait for delivery notification (depending on message type) //SENT	// inviato, non attende delivery
    //    [XafDisplayName("l'SMS è stato correttamente ricevuto")]
    //    [ImageName("State_Priority_Low")]
    //    DLVRD,		// the sms has been correctly delivered to the mobile phone   DLVRD	// l'SMS è stato correttamente ricevuto
    //    [XafDisplayName("errore in invio dell'SMS")]
    //    [ImageName("State_Priority_Low")]
    //    ERROR,		// error sending sms   ERROR	// errore in invio dell'SMS
    //    [XafDisplayName("l'operatore non ha fornito informazioni sull'SMS entro le 48 ore")]
    //    [ImageName("State_Priority_Low")]
    //    TIMEOUT,	// cannot deliver sms to the mobile in 48 hours  TIMEOUT	// l'operatore non ha fornito informazioni sull'SMS entro le 48 ore
    //    [XafDisplayName("troppi SMS per lo stesso destinatario nelle ultime 24 ore")]
    //    [ImageName("State_Priority_Low")]
    //    TOOM4NUM,	// too many messages sent to this number (spam warning)  TOOM4NUM	// troppi SMS per lo stesso destinatario nelle ultime 24 ore
    //    [XafDisplayName("troppi SMS inviati dall'utente nelle ultime 24 ore")]
    //    [ImageName("State_Priority_Low")]
    //    TOOM4USER,	// too many messages sent by this user  TOOM4USER	// troppi SMS inviati dall'utente nelle ultime 24 ore
    //    [XafDisplayName("prefisso SMS non valido o sconosciuto")]
    //    [ImageName("State_Priority_Low")]
    //    UNKNPFX,	// unknown/unparsable mobile phone prefixUNKNPFX	// prefisso SMS non valido o sconosciuto
    //    [XafDisplayName("numero di telefono del destinatario non valido o sconosciuto")]
    //    [ImageName("State_Priority_Low")]
    //    UNKNRCPT,	// unknown recipient   UNKNRCPT	// numero di telefono del destinatario non valido o sconosciuto
    //    [XafDisplayName("messaggio inviato, in attesa di delivery")]
    //    [ImageName("State_Priority_Low")]
    //    WAIT4DLVR,	// message sent, waiting for delivery notification WAIT4DLVR	// messaggio inviato, in attesa di delivery

    //    [XafDisplayName("in attesa, non ancora inviato")]
    //    [ImageName("State_Priority_Low")]
    //    WAITING,	// not yet sent (still active)WAITING	// in attesa, non ancora inviato
    //    [XafDisplayName("stato sconosciuto")]
    //    [ImageName("State_Priority_Low")]
    //    UNKNOWN,		// received an unknown status code from server (should never happen!)UNKNOWN	// stato sconosciuto
    //    /// <summary>
    //    ///  SATO INVIO SMS GENERICO (sopra è di dettaglio)
    //    /// </summary>
    //    [XafDisplayName("consegnato.")]
    //    [ImageName("State_Priority_Low")]
    //    CONSEGNATO_SMSGen,	//  è stato consegnato      -  13    
    //    [XafDisplayName("in attesa ...")]
    //    [ImageName("State_Priority_Low")]
    //    INATTESA_SMSGen,		//                           --  14

    //    ///////-----------------------------------        
    //    //   da qui mail                  MAIL
    //    [XafDisplayName("Inviata")]
    //    Inviata = 100,
    //    [XafDisplayName("Errore nell'Invio")]
    //    ErrorediInvio = 101,
    //    [XafDisplayName("non Inviata")]
    //    NonInviata = 102,

    //}

}
