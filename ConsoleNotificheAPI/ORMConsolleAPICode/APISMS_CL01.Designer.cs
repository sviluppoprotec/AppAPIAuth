//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace ConsoleNotificheAPI.Database
{

    public partial class APISMS_CL01 : XPObject
    {
        long fID;
        public long ID
        {
            get { return fID; }
            set { SetPropertyValue<long>(nameof(ID), ref fID, value); }
        }
        int fREGRDL;
        public int REGRDL
        {
            get { return fREGRDL; }
            set { SetPropertyValue<int>(nameof(REGRDL), ref fREGRDL, value); }
        }
        Guid fTOKEN;
        public Guid TOKEN
        {
            get { return fTOKEN; }
            set { SetPropertyValue<Guid>(nameof(TOKEN), ref fTOKEN, value); }
        }
        string fTIPOLOGIASMS;
        public string TIPOLOGIASMS
        {
            get { return fTIPOLOGIASMS; }
            set { SetPropertyValue<string>(nameof(TIPOLOGIASMS), ref fTIPOLOGIASMS, value); }
        }
        string fDESTSMS;
        [Size(4000)]
        public string DESTSMS
        {
            get { return fDESTSMS; }
            set { SetPropertyValue<string>(nameof(DESTSMS), ref fDESTSMS, value); }
        }
        string fUTENTE;
        [Size(50)]
        public string UTENTE
        {
            get { return fUTENTE; }
            set { SetPropertyValue<string>(nameof(UTENTE), ref fUTENTE, value); }
        }
        string fCORPOSMS;
        [Size(4000)]
        public string CORPOSMS
        {
            get { return fCORPOSMS; }
            set { SetPropertyValue<string>(nameof(CORPOSMS), ref fCORPOSMS, value); }
        }
        string fSISTEMA;
        [Size(25)]
        public string SISTEMA
        {
            get { return fSISTEMA; }
            set { SetPropertyValue<string>(nameof(SISTEMA), ref fSISTEMA, value); }
        }
        DateTime fDATAORA_ULTIMOGET;
        public DateTime DATAORA_ULTIMOGET
        {
            get { return fDATAORA_ULTIMOGET; }
            set { SetPropertyValue<DateTime>(nameof(DATAORA_ULTIMOGET), ref fDATAORA_ULTIMOGET, value); }
        }
        DateTime fDATAORA_ULTIMOPUT;
        public DateTime DATAORA_ULTIMOPUT
        {
            get { return fDATAORA_ULTIMOPUT; }
            set { SetPropertyValue<DateTime>(nameof(DATAORA_ULTIMOPUT), ref fDATAORA_ULTIMOPUT, value); }
        }
        DateTime fDATAORAUPDATE;
        public DateTime DATAORAUPDATE
        {
            get { return fDATAORAUPDATE; }
            set { SetPropertyValue<DateTime>(nameof(DATAORAUPDATE), ref fDATAORAUPDATE, value); }
        }
        bool fISRECEIVED;
        public bool ISRECEIVED
        {
            get { return fISRECEIVED; }
            set { SetPropertyValue<bool>(nameof(ISRECEIVED), ref fISRECEIVED, value); }
        }
        bool fISSENT;
        public bool ISSENT
        {
            get { return fISSENT; }
            set { SetPropertyValue<bool>(nameof(ISSENT), ref fISSENT, value); }
        }
        bool fISCLOSED;
        public bool ISCLOSED
        {
            get { return fISCLOSED; }
            set { SetPropertyValue<bool>(nameof(ISCLOSED), ref fISCLOSED, value); }
        }
        int fESITO;
        public int ESITO
        {
            get { return fESITO; }
            set { SetPropertyValue<int>(nameof(ESITO), ref fESITO, value); }
        }
        string fCLIENTE;
        [Size(12)]
        public string CLIENTE
        {
            get { return fCLIENTE; }
            set { SetPropertyValue<string>(nameof(CLIENTE), ref fCLIENTE, value); }
        }
        int fSTATO;
        public int STATO
        {
            get { return fSTATO; }
            set { SetPropertyValue<int>(nameof(STATO), ref fSTATO, value); }
        }
        int fQUALITAINVIO;
        public int QUALITAINVIO
        {
            get { return fQUALITAINVIO; }
            set { SetPropertyValue<int>(nameof(QUALITAINVIO), ref fQUALITAINVIO, value); }
        }
        int fTIPOINVIO;
        public int TIPOINVIO
        {
            get { return fTIPOINVIO; }
            set { SetPropertyValue<int>(nameof(TIPOINVIO), ref fTIPOINVIO, value); }
        }
        int fNRINVIO;
        public int NRINVIO
        {
            get { return fNRINVIO; }
            set { SetPropertyValue<int>(nameof(NRINVIO), ref fNRINVIO, value); }
        }
        string fCENTROCOSTO;
        [Size(12)]
        public string CENTROCOSTO
        {
            get { return fCENTROCOSTO; }
            set { SetPropertyValue<string>(nameof(CENTROCOSTO), ref fCENTROCOSTO, value); }
        }
        string fAREABUSINESS;
        [Size(12)]
        public string AREABUSINESS
        {
            get { return fAREABUSINESS; }
            set { SetPropertyValue<string>(nameof(AREABUSINESS), ref fAREABUSINESS, value); }
        }
    }

}
