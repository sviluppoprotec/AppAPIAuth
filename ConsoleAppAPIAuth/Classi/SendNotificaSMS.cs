using AppAPIAuth.Module.BusinessObjects;
using ConsoleAppAPIAuth.Model;
using ConsoleAppAPIAuth.XpoHelper;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        internal void Run( string CurentUser, string AppPath, DateTime dataSessioneLancio, string sessione_ID)
        {
            //string sessione_ID = Guid.NewGuid().ToString();
            string str_dataSessione = dataSessioneLancio.ToString("yyy/MM/dd HH:mm:ss.fff");//CONVERT(datetime,'2020/08/07 13:15:56.256',121 ) 
            //Progetto = GetProggetto(Connessione);
            AddLog(CurentUser,"API", "inizio run RunEmailSms", DateTime.Now.ToString(), sessione_ID);
            bool tuttiSpeditiSenzaErrori = true;
            int AvvisiSpedizioni_Id = 0;
            DateTime DataInizioTransazione = DateTime.Now;
            List<Trace> TransazioniImp = null;
            string vstring = "Job Invio Email/Sms";
            //BindingList<CAMS.Module.DBMail.DCDatiSMSMail> objDCDatiSMSMail = new BindingList<CAMS.Module.DBMail.DCDatiSMSMail>();
            bool SpediscieMail = false;
            try
            {
                using (UnitOfWork uw = XpoHelperAudit.GetNewUnitOfWork())
                {
                    //AuditTrailService.Instance.BeginSessionAudit(uw, AuditTrailStrategy.OnObjectChanged);
                    //*******************************************************************
                    Console.WriteLine("{0}", vstring);
                    //RegistroTransazioni tran = uw.FindObject<AppAPIAuth>(CriteriaOperator.Parse("Descrizione = ?", vstring));
                    //foreach (var tran in TransazioniImp)
                    
                        tuttiSpeditiSenzaErrori = true;
                        AvvisiSpedizioni_Id = 0;
                        // trovo gli avvisi spedizioni in distinct
                        List<Avvisi> qavvisiSpedizioni = uw.Query<APISMS_CL01>()
                            .Where(x => x.ISCLOSED == false)
                            .Where(x => x.DATAORAUPDATE == null)
                            .OrderBy(x => x.Oid)
                            .Select(x =>
                            new Avvisi()
                            {
                                id = x.Oid, // x.AvvisiSpedizioni.Oid,
                                status = SMSStatus.Inviato //  x.AvvisiSpedizioni.Status
                            }).Distinct().ToList<Avvisi>();
                        // giro avvisi spdizioni
                        foreach (Avvisi avvisiSpedizioni in qavvisiSpedizioni.OrderBy(o => o.status)) // giro su avvisi spedizioni
                        {
                            int id_avvisi = avvisiSpedizioni.id;
                            tuttiSpeditiSenzaErrori = true;
                            APISMS_CL01 APISms = uw.GetObjectByKey<APISMS_CL01>(avvisiSpedizioni.id);

                            SMSAruba.GestioneSMS(telefoniDestinatari: APISms.DESTSMS, SMSAruba.MESSAGE_MEDIUM_QUALITY, Messaggio: APISms.CORPOSMS);
                            switch (APISms.TIPOINVIO)
                            {
                                case 0: // Aruba MEDIUM
                                SMSAruba.GestioneSMS(telefoniDestinatari: APISms.DESTSMS, SMSAruba.MESSAGE_MEDIUM_QUALITY, Messaggio: APISms.CORPOSMS);
                                    break;
                                case 1: // Aruba HIGH
                                SMSAruba.GestioneSMS(telefoniDestinatari: APISms.DESTSMS, SMSAruba.MESSAGE_HIGH_QUALITY, Messaggio: APISms.CORPOSMS);
                                    break;
                            case 2: // Telegram
                                SMSAruba.GestioneSMS(telefoniDestinatari: APISms.DESTSMS, SMSAruba.MESSAGE_HIGH_QUALITY, Messaggio: APISms.CORPOSMS);
                                NotificaTelegram.SendMSG ( 2143589472, APISms.CORPOSMS);
                                break;
                            default:
                                    //avvSpedizionicorr.Status = myTaskStatus.FallitoUlterioreInvio;
                                    break;
                            }
                        }                      
                       //  fine for avvisispedizioni
                        //tran.DataUltimaEsecuzione = DateTime.Now;
                        ////tran.DataPianificata = DateTime.Now.AddMinutes(5);
                        //tran.StatoElaborazioneJob = StatoElaborazioneJob.EseguitoExec;
                        //tran.Save();
                        uw.CommitChanges();
                    //*******************************************************************************************
                    //AuditTrailService.Instance.QueryCurrentUserName += OnAuditTrailServiceInstanceQueryCurrentUserName;
                    //AuditTrailService.Instance.SaveAuditData(uw);
                    //AuditTrailService.Instance.QueryCurrentUserName -= OnAuditTrailServiceInstanceQueryCurrentUserName;
                } // fine if transazioni
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} errore", ex);
                AddLog(CurentUser, "API","ERRORE run RunEmailSms", DateTime.Now.ToString() + " " + ex.Message, sessione_ID);
                //throw;
            }
            AddLog(CurentUser, "API", "fine run RunEmailSms", DateTime.Now.ToString(), sessione_ID);
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
