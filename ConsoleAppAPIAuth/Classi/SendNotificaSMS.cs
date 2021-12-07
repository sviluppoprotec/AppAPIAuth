using AppAPIAuth.Module.BusinessObjects;
using ConsoleAppAPIAuth.Classi.SmsSender;
using ConsoleAppAPIAuth.Model;
using ConsoleAppAPIAuth.XpoHelper;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAPIAuth.Classi
{
    class SendNotificaSMS : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        string Progetto { get; set; }
        public object SendMSG { get; private set; }

        internal void Run(string CurentUser, string tipo, DateTime dataSessioneLancio, string sessione_ID)
        {

            Logger.FileLogger logger = new Logger.FileLogger("ConsoleAppApiAuth");
            //string sessione_ID = Guid.NewGuid().ToString();
            string str_dataSessione = dataSessioneLancio.ToString("yyy/MM/dd HH:mm:ss.fff");//CONVERT(datetime,'2020/08/07 13:15:56.256',121 ) 
            //Progetto = GetProggetto(Connessione);
            AddLog(CurentUser, "API", "inizio run RunEmailSms", DateTime.Now.ToString(), sessione_ID);
            //bool tuttiSpeditiSenzaErrori = true;
            int CreditiResidui = 0;
            DateTime DataInizioTransazione = DateTime.Now;
            //List<Trace> TransazioniImp = null;
            string vstring = "Job Invio Email/Sms";
            //BindingList<CAMS.Module.DBMail.DCDatiSMSMail> objDCDatiSMSMail = new BindingList<CAMS.Module.DBMail.DCDatiSMSMail>();
            //bool SpediscieMail = false;
            DateTime datalimiteinferiorequesry = DateTime.Now.AddHours(-5);
            try
            {

                using (UnitOfWork uw = XpoHelperAudit.GetNewUnitOfWork())
                {
                    //AuditTrailService.Instance.BeginSessionAudit(uw, AuditTrailStrategy.OnObjectChanged);
                    //*******************************************************************
                    Console.WriteLine("{0}", vstring);
                    if (tipo == "Spedisci")
                    {
                        List<Avvisi> qavvisiSpedizioni = uw.Query<APISMS_CL01>()
                            .Where(x => x.ISCLOSED == false && x.TIPOINVIO == (int)TipoInvio.SMS && x.STATO == (int)StatoInvio.Predisposto) // false 1 1
                                                                                                                                            //.Where(x => x.DATAORA_ULTIMOPUT > datalimiteinferiorequesry)
                            .OrderBy(x => x.Oid)
                            .Select(x =>
                            new Avvisi()
                            {
                                id = x.Oid, // x.AvvisiSpedizioni.Oid,
                                telefoniDestinatari = x.DESTSMS,
                                CORPOSMS = x.CORPOSMS,
                                QualitaInvio = x.QUALITAINVIO,
                                status = SMSStatus.Inviato, //  x.AvvisiSpedizioni.Status,
                                tipologiaSMS = x.TIPOLOGIASMS
                            }).ToList<Avvisi>();
                        // giro avvisi spdizioni
                        //SMSSent RispostaInvio = null;
                        foreach (Avvisi avviso in qavvisiSpedizioni.OrderBy(o => o.status)) // .Where(x => x.id == 9) giro su avvisi spedizioni
                        {
                            //int id_avvisi = avviso.id;
                            //tuttiSpeditiSenzaErrori = true; +39
                            switch(avviso.tipologiaSMS){
                                case "SMS01":
                                    SendSMSAruba(uw, avviso, CreditiResidui);
                                    break;
                                case "SMS02":
                                    SendSMSSmsSender(uw, avviso, CreditiResidui);
                                    break;
                                case "SMS03":
                                    SendSMSSmsHosting(uw, avviso, CreditiResidui);
                                    break;
                                default:
                                    logger.Log($"ERRORE: Tipologia sms {avviso.tipologiaSMS} non definita");
                                    break;
                            }
                        }
                    }
                    //  fine for avvisispedizioni

                    if (tipo == "Spedisci" || tipo == "Controlla")
                    {
                        List<Avvisi> qEsitoSpedizioni = uw.Query<APISMS_CL01>()
                       .Where(x => x.ISCLOSED == false && x.TIPOINVIO == (int)TipoInvio.SMS && x.STATO == (int)StatoInvio.Inviato)
                       //.Where(x => x.DATAORA_ULTIMOPUT > datalimiteinferiorequesry)
                       .OrderBy(x => x.Oid)
                       .Select(x =>
                       new Avvisi()
                       {
                           id = x.Oid,
                           ID_SMS = x.ID_SMS,
                           telefoniDestinatari = x.DESTSMS,
                           CORPOSMS = x.CORPOSMS,
                           QualitaInvio = x.QUALITAINVIO
                           //status = x.STATO 
                       }).ToList<Avvisi>();
                        foreach (Avvisi avviso in qEsitoSpedizioni.OrderBy(o => o.status)) // giro su avvisi spedizioni
                        {
                            CheckSMSAruba(uw, avviso);
                        }
                        //*******************************************************************************************
                        //AuditTrailService.Instance.QueryCurrentUserName += OnAuditTrailServiceInstanceQueryCurrentUserName;
                        //AuditTrailService.Instance.SaveAuditData(uw);
                        //AuditTrailService.Instance.QueryCurrentUserName -= OnAuditTrailServiceInstanceQueryCurrentUserName;
                    }
                } // fine if transazioni
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} errore", ex);
                AddLog(CurentUser, "API", "ERRORE run RunEmailSms", DateTime.Now.ToString() + " " + ex.Message, sessione_ID);
                //throw;
            }
            AddLog(CurentUser, "API", "fine run RunEmailSms", DateTime.Now.ToString(), sessione_ID);
        }

        #region aruba
        private static void SendSMSAruba(UnitOfWork uw, Avvisi avviso, int CreditiResidui)
        {
            string telDestinatari = avviso.telefoniDestinatari.Replace(";", "").Replace("-", "").Replace("(0039)", "+39");
            string avvisoCorpo = avviso.CORPOSMS;//.Substring(1, 300)
            Console.WriteLine("telDestinatari{0}  MESSAGE_ {1} CORPOSMS!{2}",
                telDestinatari,
                SMSAruba.MESSAGE_HIGH_QUALITY,
                avviso.CORPOSMS);
            SMSSent RispostaInvio = SMSAruba.GestioneSMS(telefoniDestinatari: telDestinatari,
                SMSAruba.MESSAGE_HIGH_QUALITY,
                Messaggio: avvisoCorpo);
            //switch (avviso.QualitaInvio)
            //{
            //    case 0: // Aruba nd
            //        RispostaInvio = SMSAruba.GestioneSMS(telefoniDestinatari: telDestinatari, SMSAruba.MESSAGE_MEDIUM_QUALITY, Messaggio: avviso.CORPOSMS);
            //        break;
            //    case 1: // Aruba basso
            //        RispostaInvio = SMSAruba.GestioneSMS(telefoniDestinatari: telDestinatari, SMSAruba.MESSAGE_HIGH_QUALITY, Messaggio: avviso.CORPOSMS);
            //        break;
            //    case 2: // Aruba alto
            //        RispostaInvio = SMSAruba.GestioneSMS(telefoniDestinatari: telDestinatari, SMSAruba.MESSAGE_HIGH_QUALITY, Messaggio: avviso.CORPOSMS);
            //        NotificaTelegram.SendMSG(2143589472, avviso.CORPOSMS);
            //        break;
            //    default:
            //        //avvSpedizionicorr.Status = myTaskStatus.FallitoUlterioreInvio;
            //        break;
            //}
            Console.WriteLine(RispostaInvio.result.ToString());
            StatoInvio statoInvio = StatoInvio.NonDefinito;
            if ("OK".Equals(RispostaInvio.result))
            {
                Console.WriteLine("SMS successfully sent!");
                string msg = string.Format("smsSent.order_id {0}, smsSent.remaining_credits {1}, smsSent.result {2}, , smsSent.total_sent {3}",
                    RispostaInvio.order_id, RispostaInvio.remaining_credits, RispostaInvio.result, RispostaInvio.total_sent);
                Console.WriteLine(msg);
                statoInvio = StatoInvio.Inviato;
                CreditiResidui = RispostaInvio.remaining_credits;
            }
            else
            {
                statoInvio = StatoInvio.FallitoInvio;
            }


            APISMS_CL01 APISms = uw.GetObjectByKey<APISMS_CL01>(avviso.id);
            APISms.ID_SMS = RispostaInvio.order_id;
            APISms.STATO = (int)statoInvio;
            APISms.DATAORAUPDATE = DateTime.Now;
            APISms.ESITO = (int)EsitoSMS.SENT_TO_SMSC;
            APISms.NRINVIO = RispostaInvio.total_sent;
            APISms.Save();
            uw.CommitChanges();
        }

        private static void CheckSMSAruba(UnitOfWork uw, Avvisi avviso)
        {
            StatusSMSApi RispostaStato = SMSAruba.GetSMSStato(IDSMS: avviso.ID_SMS);
            StatoInvio statoInvio = StatoInvio.NonDefinito;
            bool isClosed = false;
            EsitoSMS esito = new EsitoSMS();
            if ("OK".Equals(RispostaStato.result))
            {
                string msg = string.Format("smsSent.order_id {0}, smsSent.recipient_number {1}, smsSent.result {2} ",
                    avviso.id, RispostaStato.recipient_number, RispostaStato.result.ToString());
                Console.WriteLine(msg);
                switch (RispostaStato.recipients.status)
                {
                    case "DLVRD": // Aruba nd
                        statoInvio = StatoInvio.Completato;
                        isClosed = true;
                        break;
                    default:
                        statoInvio = StatoInvio.Inviato;
                        break;
                }
                esito = (EsitoSMS)Enum.Parse(typeof(EsitoSMS), RispostaStato.recipients.status);
            }
            else
            {
                statoInvio = StatoInvio.FallitoInvio;
                esito = EsitoSMS.ERROR;
            }
            APISMS_CL01 APISms = uw.GetObjectByKey<APISMS_CL01>(avviso.id);
            //APISms.ID_SMS = RispostaInvio.order_id;
            APISms.STATO = (int)statoInvio;
            //EsitoSMS esito = (EsitoSMS)Enum.Parse(typeof(EsitoSMS), RispostaStato.recipients.status);
            APISms.ESITO = (int)esito;
            APISms.DATAORAUPDATE = DateTime.Now;
            APISms.DATASPEDIZIONE = GetDataSpedizione(RispostaStato.recipients.delivery_date);
            APISms.ISCLOSED = isClosed;
            APISms.Save();
            uw.CommitChanges();
        }
        #endregion


        #region SmsSender
        private static void SendSMSSmsSender(UnitOfWork uw, Avvisi avviso, int CreditiResidui)
        {
            string[] telDestinatari = avviso.telefoniDestinatari.Replace("-", "").Replace("(0039)", "").Split(';');
            string avvisoCorpo = avviso.CORPOSMS;//.Substring(1, 300)
            Console.WriteLine("SmsSender: telDestinatari{0}  CORPOSMS!{2}",
                telDestinatari,
                avviso.CORPOSMS);
            SmsSenderService.InvioSmsResult RispostaInvio = SmsSenderHandler.Invia(telDestinatari,avvisoCorpo);
           
            Console.WriteLine(RispostaInvio.ToString());
            StatoInvio statoInvio = StatoInvio.NonDefinito;
            if (RispostaInvio.Successo)
            {
                Console.WriteLine("SMS successfully sent!");
                string msg = string.Format("smsSent.order_id {0}, smsSent.remaining_credits {1}, smsSent.result {2}, , smsSent.total_sent {3}",
                    RispostaInvio.IdUnivoco, CreditiResidui, RispostaInvio.Successo?"OK": "KO", 1);
                Console.WriteLine(msg);
                statoInvio = StatoInvio.Inviato;
                // TODO: come avere i crediti residui
                //CreditiResidui = RispostaInvio.remaining_credits;
            }
            else
            {
                statoInvio = StatoInvio.FallitoInvio;
            }


            APISMS_CL01 APISms = uw.GetObjectByKey<APISMS_CL01>(avviso.id);
            APISms.ID_SMS = RispostaInvio.IdUnivoco;
            APISms.STATO = (int)statoInvio;
            APISms.DATAORAUPDATE = DateTime.Now;
            APISms.ESITO = (int)EsitoSMS.SENT_TO_SMSC;
            APISms.NRINVIO = 1;
            APISms.Save();
            uw.CommitChanges();
        }

        private static void CheckSMSSmsSender(UnitOfWork uw, Avvisi avviso)
        {
            SmsSenderService.StatoSmsResult RispostaStato = SmsSenderHandler.GetStatoSms(avviso.ID_SMS);
            StatoInvio statoInvio = StatoInvio.NonDefinito;
                var statoSms = RispostaStato.StatiSms.FirstOrDefault();
            bool isClosed = false;
            EsitoSMSSmsSender esitoSmsSender = new EsitoSMSSmsSender();
            if (RispostaStato.Successo)
            {
                if (statoSms != null)
                {
                    string msg = string.Format("smsSent.order_id {0}, smsSent.recipient_number {1}, smsSent.result {2} ",
                        avviso.id, statoSms.Numero, RispostaStato.Successo ? "OK" : "KO");
                    Console.WriteLine(msg);
                    switch (statoSms.Status)
                    {
                        case "DELIVERED": // Aruba nd
                            statoInvio = StatoInvio.Completato;
                            isClosed = true;
                            break;
                        default:
                            statoInvio = StatoInvio.Inviato;
                            break;
                    }
                    esitoSmsSender = (EsitoSMSSmsSender)Enum.Parse(typeof(EsitoSMSSmsSender), statoSms.Status);
                } else {

                    statoInvio = StatoInvio.Inviato;
                    esitoSmsSender = EsitoSMSSmsSender.SENT;
                }
            }
            else
            {
                statoInvio = StatoInvio.FallitoInvio;
                esitoSmsSender = EsitoSMSSmsSender.ERROR;
            }
            APISMS_CL01 APISms = uw.GetObjectByKey<APISMS_CL01>(avviso.id);
            //APISms.ID_SMS = RispostaInvio.order_id;
            APISms.STATO = (int)statoInvio;
            //EsitoSMS esito = (EsitoSMS)Enum.Parse(typeof(EsitoSMS), RispostaStato.recipients.status);
            APISms.ESITO = (int)esitoSmsSender;
            APISms.DATAORAUPDATE = DateTime.Now;
            APISms.DATASPEDIZIONE = GetDataSpedizione(statoSms.DataOra);
            APISms.ISCLOSED = isClosed;
            APISms.Save();
            uw.CommitChanges();
        }
        #endregion
        #region SmsHosting


        private static void SendSMSSmsHosting(UnitOfWork uw, Avvisi avviso, int CreditiResidui)
        {
            string telDestinatari = avviso.telefoniDestinatari.Replace("-", "").Replace("(0039)", "").Split(';').First();
            string avvisoCorpo = avviso.CORPOSMS;//.Substring(1, 300)
            Console.WriteLine("SmsSender: telDestinatari{0}  CORPOSMS!{2}",
                telDestinatari,
                avviso.CORPOSMS);
            SmsHosting.SmsHostingResponse RispostaInvio = SmsHosting.SmsHostingHandler.Invia(telDestinatari, avvisoCorpo);
            var sms = RispostaInvio.sms.FirstOrDefault();
            Console.WriteLine(RispostaInvio.ToString());
            StatoInvio statoInvio = StatoInvio.NonDefinito;
            if (RispostaInvio.ErrorCode.Equals(0))
            {
                Console.WriteLine("SMS successfully sent!");
                string msg = string.Format("smsSent.order_id {0}, smsSent.remaining_credits {1}, smsSent.result {2}, , smsSent.total_sent {3}",
                    sms?.Id, CreditiResidui, RispostaInvio.ErrorCode == 0 ? "OK" : "KO", 1);
                Console.WriteLine(msg);
                statoInvio = StatoInvio.Inviato;
                // TODO: come avere i crediti residui
                //CreditiResidui = RispostaInvio.remaining_credits;
            }
            else
            {
                statoInvio = StatoInvio.FallitoInvio;
            }


            APISMS_CL01 APISms = uw.GetObjectByKey<APISMS_CL01>(avviso.id);
            APISms.ID_SMS = sms.Id.ToString();
            APISms.STATO = (int)statoInvio;
            APISms.DATAORAUPDATE = DateTime.Now;
            APISms.ESITO = (int)EsitoSMS.SENT_TO_SMSC;
            APISms.NRINVIO = 1;
            APISms.Save();
            uw.CommitChanges();
        }
        private static void CheckSMSSmsHosting(UnitOfWork uw, Avvisi avviso)
        {
            SmsHosting.SmsHostingCheckMessageResponse RispostaStato = SmsHosting.SmsHostingHandler.CheckSms(avviso.ID_SMS);
            StatoInvio statoInvio = StatoInvio.NonDefinito;
            var statoSms = RispostaStato.SmsList.FirstOrDefault();
            bool isClosed = false;
            EsitoSMSSmsSender esitoSmsSender = new EsitoSMSSmsSender();
            if (RispostaStato.SmsList.Count>0)
            {
                if (statoSms != null)
                {
                    string msg = string.Format("smsSent.order_id {0}, smsSent.result {2} ",
                        avviso.id,  RispostaStato.SmsList.Count>0 ? "OK" : "KO");
                    Console.WriteLine(msg);
                    switch (statoSms.status)
                    {
                        case "DELIVERED": // Aruba nd
                            statoInvio = StatoInvio.Completato;
                            isClosed = true;
                            break;
                        default:
                            statoInvio = StatoInvio.Inviato;
                            break;
                    }
                    esitoSmsSender = (EsitoSMSSmsSender)Enum.Parse(typeof(EsitoSMSSmsSender), statoSms.status);
                }
                else
                {

                    statoInvio = StatoInvio.Inviato;
                    esitoSmsSender = EsitoSMSSmsSender.SENT;
                }
            }
            else
            {
                statoInvio = StatoInvio.FallitoInvio;
                esitoSmsSender = EsitoSMSSmsSender.ERROR;
            }
            APISMS_CL01 APISms = uw.GetObjectByKey<APISMS_CL01>(avviso.id);
            //APISms.ID_SMS = RispostaInvio.order_id;
            APISms.STATO = (int)statoInvio;
            //EsitoSMS esito = (EsitoSMS)Enum.Parse(typeof(EsitoSMS), RispostaStato.recipients.status);
            APISms.ESITO = (int)esitoSmsSender;
            APISms.DATAORAUPDATE = DateTime.Now;
            APISms.DATASPEDIZIONE = statoSms.sentDate;
            APISms.ISCLOSED = isClosed;
            APISms.Save();
            uw.CommitChanges();
        }

        #endregion


        private static DateTime GetDataSpedizione(string dateString)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            DateTime dateTime10 = DateTime.Now; // DateTime.ParseExact(dateString, "yyyyMMddHHmmss", provider);
            return dateTime10;
        }

        public int AddLog(string UserName, string Evento, string Descrizione, string Corpo, string SessioneWEB)
        {
            int oidLog = 0;
            string n_Descrizione = Progetto + "-" + Descrizione;
            if (n_Descrizione.Length > 3999)
                n_Descrizione = n_Descrizione.Substring(1, 3996) + "...";

            string n_Corpo = Corpo;
            if (Corpo.Length > 3999)
                n_Corpo = Corpo.Substring(1, 3996) + "...";

            using (UnitOfWork uw = XpoHelperAudit.GetNewUnitOfWork())
            {
                TraceLog logdb = new TraceLog(uw);
                logdb.Utente = UserName;
                logdb.Evento = Evento;
                logdb.Descrizione = n_Descrizione;
                logdb.DataAggiornamento = DateTime.Now;
                logdb.Evento = n_Corpo;
                logdb.SessioneWEB = SessioneWEB;
                logdb.Save();
                uw.CommitChanges();
                oidLog = logdb.Oid;
            }
            return oidLog;
        }
    }
}
