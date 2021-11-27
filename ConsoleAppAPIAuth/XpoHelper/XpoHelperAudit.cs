//using CAMS.Module.DBTask;
//using CAMS.Module.DBAux;
using AppAPIAuth.Module.BusinessObjects;
using DevExpress.Persistent.AuditTrail;
//namespace ConsoleAppAPIAuth.XpoHelper
//{
//    class XpoHelperAudit
//    {
//    }
//}

using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System;
using System.Configuration;
using bi = DevExpress.Persistent.BaseImpl;

namespace ConsoleAppAPIAuth.XpoHelper
{
    public class XpoHelperAudit
    {
        private const string ConnectionStringName = "ConnectionString";
        private static string _ConnectionString;

        public static string connectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }


        static XpoHelperAudit()
        {
            //    static Type[] persistentTypes = new Type[] {
            //    typeof(APIAUT),
            //    typeof(APISMS_CL01)
            //};
            XPDictionary dict = new ReflectionDictionary();
            dict.GetDataStoreSchema(typeof(APIAUT).Assembly);
            AuditTrailService.Instance.SetXPDictionary(dict);
            AuditTrailService.Instance.AuditDataStore = new AuditDataStore<bi.AuditDataItemPersistent, bi.AuditedObjectWeakReference>();
        }

        public static Session GetNewSession()
        {
            return new Session(DataLayer);
        }

        public static UnitOfWork GetNewUnitOfWork()
        {
            return new UnitOfWork(DataLayer);
        }

        private readonly static object lockObject = new object();

        static volatile IDataLayer fDataLayer;
        static IDataLayer DataLayer
        {
            get
            {
                if (fDataLayer == null)
                {
                    lock (lockObject)
                    {
                        if (fDataLayer == null)
                        {
                            fDataLayer = GetDataLayer();
                        }
                    }
                }
                return fDataLayer;
            }
        }

        private static IDataLayer GetDataLayer()
        {
            string conn = ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            //string conn = ConfigurationSettings.AppSettings["ConnectionString"];
            XpoDefault.Session = null;
            XPDictionary dict = new ReflectionDictionary();
            dict.GetDataStoreSchema(typeof(APIAUT).Assembly, typeof(bi.AuditDataItemPersistent).Assembly, typeof(AuditDataItem).Assembly);
            // aggiunto da mia 
            IDataStore store = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaAlreadyExists);
            IDataLayer dl = new ThreadSafeDataLayer(dict, store);
            return dl;
            ////  
        }

        //public static string GetConnessioneStringaOracle(string ConnessioneBase)
        //{
        //    var StrConn = string.Empty;
        //    var datasource = "Data Source=";
        //    if (ConnessioneBase.Contains("XpoProvider=Oracle;Data Source="))
        //    {
        //        datasource = "XpoProvider=Oracle;Data Source=";
        //    }
        //    var stringSeparators = new string[] { datasource };
        //    var ReturnLong = ConnessioneBase.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
        //    var ReturnCorto = ReturnLong[0].Split(new Char[] { ';' });
        //    var DataSorce = ReturnCorto[0].ToString().Trim();

        //    var stringSeparators1 = new string[] { "User ID=" };
        //    var ReturnLong1 = ConnessioneBase.Split(stringSeparators1, StringSplitOptions.RemoveEmptyEntries);
        //    var ReturnCorto1 = ReturnLong1[1].Split(new Char[] { ';' });
        //    var User = ReturnCorto1[0].ToString().Trim();

        //    var stringSeparators2 = new string[] { "Password=" };
        //    var ReturnLong2 = ConnessioneBase.Split(stringSeparators2, StringSplitOptions.RemoveEmptyEntries);
        //    var ReturnCorto2 = ReturnLong2[1].Split(new Char[] { ';' });
        //    var pass = ReturnCorto2[0].ToString().Trim();

        //    StrConn = String.Format("Data Source={0};User Id={1};Password={2};", DataSorce, User, pass);

        //    return StrConn;
        //}
    }
}
