using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPIAuth.Module.BusinessObjects
{
    [NavigationItem(true)]
    [DevExpress.ExpressApp.Model.ModelDefault("Caption", "Log di Sistema")]
    [ImageName("ShowTestReport")]
    public class TraceLog : XPObject
    {
        public TraceLog() : base() { }

        public TraceLog(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Oid == -1)
                DataAggiornamento = DateTime.MinValue;
        }

        private const string DateAndTimeOfDayEditMask = "dd/MM/yyyy H:mm:ss";

        private string f_Utente;
        [Persistent("UTENTE"), Size(300), DisplayName("Utente")]
        [DbType("varchar(300)")]
        public string Utente
        {
            get { return f_Utente; }
            set { SetPropertyValue<string>("Utente", ref f_Utente, value); }
        }

        private string _evento;
        [Persistent("EVENTO"), Size(300), DisplayName("Evento")]
        [DbType("varchar(300)")]
        public string Evento
        {
            get { return _evento; }
            set { SetPropertyValue<string>("Evento", ref _evento, value); }
        }
        private string fDescrizione;
        [Persistent("DESCRIZIONE"), Size(4000)]
        [DbType("varchar(4000)")]
        public string Descrizione
        {
            get { return fDescrizione; }
            set { SetPropertyValue<string>("Descrizione", ref fDescrizione, value); }
        }

        private DateTime fDataAggiornamento;
        [Persistent("DATAUPDATE"), DisplayName("Data Aggiornamento")]
        [System.ComponentModel.Browsable(false)]
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "{0:" + DateAndTimeOfDayEditMask + "}")]
        [DevExpress.ExpressApp.Model.ModelDefault("EditMask", DateAndTimeOfDayEditMask)]
        public DateTime DataAggiornamento
        {
            get { return fDataAggiornamento; }
            set { SetPropertyValue<DateTime>("DataAggiornamento", ref fDataAggiornamento, value); }
        }

        private string fSessioneWEB;
        [Persistent("SESSIONEWEB"), Size(100), DisplayName("Sessione WEB")]
        [DbType("varchar(100)")]
        //[System.ComponentModel.Browsable(false)]
        public string SessioneWEB
        {
            get { return fSessioneWEB; }
            set { SetPropertyValue<string>("SessioneWEB", ref fSessioneWEB, value); }
        }
    }
}
