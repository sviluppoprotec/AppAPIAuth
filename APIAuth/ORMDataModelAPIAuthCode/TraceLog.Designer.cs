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
namespace APIAuth.Database
{

    public partial class TraceLog : XPObject
    {
        string fUTENTE;
        [Size(300)]
        public string UTENTE
        {
            get { return fUTENTE; }
            set { SetPropertyValue<string>(nameof(UTENTE), ref fUTENTE, value); }
        }
        string fEVENTO;
        [Size(300)]
        public string EVENTO
        {
            get { return fEVENTO; }
            set { SetPropertyValue<string>(nameof(EVENTO), ref fEVENTO, value); }
        }
        string fDESCRIZIONE;
        [Size(4000)]
        public string DESCRIZIONE
        {
            get { return fDESCRIZIONE; }
            set { SetPropertyValue<string>(nameof(DESCRIZIONE), ref fDESCRIZIONE, value); }
        }
        DateTime fDATAUPDATE;
        public DateTime DATAUPDATE
        {
            get { return fDATAUPDATE; }
            set { SetPropertyValue<DateTime>(nameof(DATAUPDATE), ref fDATAUPDATE, value); }
        }
        string fSESSIONEWEB;
        public string SESSIONEWEB
        {
            get { return fSESSIONEWEB; }
            set { SetPropertyValue<string>(nameof(SESSIONEWEB), ref fSESSIONEWEB, value); }
        }
    }

}
