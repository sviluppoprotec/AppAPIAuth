using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AppAPIAuth.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class APISMS_CL01 : XPObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public APISMS_CL01(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
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

        DateTime fDATASPEDIZIONE;
        public DateTime DATASPEDIZIONE
        {
            get { return fDATASPEDIZIONE; }
            set { SetPropertyValue<DateTime>(nameof(DATASPEDIZIONE), ref fDATASPEDIZIONE, value); }
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
        string fID_SMS;
        public string ID_SMS
        {
            get { return fID_SMS; }
            set { SetPropertyValue<string>(nameof(ID_SMS), ref fID_SMS, value); }
        }
        string fOperatore;
        public string Operatore
        {
            get { return fOperatore; }
            set { SetPropertyValue<string>(nameof(Operatore), ref fOperatore, value); }
        }

        decimal fCreditoResiduo;
        public decimal CreditoResiduo
        {
            get { return fCreditoResiduo; }
            set { SetPropertyValue<decimal>(nameof(CreditoResiduo), ref fCreditoResiduo, value); }
        }

        decimal fCosto;
        public decimal Costo
        {
            get { return fCosto; }
            set { SetPropertyValue<decimal>(nameof(Costo), ref fCosto, value); }
        }
    }

 
}