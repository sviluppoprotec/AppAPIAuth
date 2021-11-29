using DevExpress.Xpo;
using ApiAuth.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuth.Database;
using NSwag.Annotations;
using System.Net;

namespace ApiAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AggSmSCL01 : ControllerBase
    {

        private UnitOfWork uow;
        public AggSmSCL01(UnitOfWork uow) // nuovo
        {
            this.uow = uow;
        }
        [Produces("application/json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Smscl01>>> GetTodoItems()
        {
            var _SmsOut = await uow.Query<APISMS_CL01>()
                   .Where(w => w.CLIENTE == "Engie Servizi SpA")
                   .Select(s => new
             Smscl01
                   {
                       Id = s.ID,
                       CorpoSMS = s.CORPOSMS,
                       Esito = s.ESITO,
                       Token = Guid.NewGuid()
                   }
                 ).Take(100).ToListAsync<Smscl01>();

            return _SmsOut;
        }

        [Produces("application/json")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Smscl01>> Get(int id, string Sistema, string Cliente)
        {

            var vSmsOut = await uow.Query<APISMS_CL01>()
                .Where(w => w.CLIENTE == "Engie Servizi SpA" || w.SISTEMA.Contains("EAMSPA") || w.SISTEMA.Contains("EAMSSL"))
                   .Where(w => w.ID == id)
                .Select(s => new
          Smscl01
                {
                    Id = s.ID,
                    Esito = s.ESITO,
                    Cliente=s.CLIENTE,
                    Sistema=s.SISTEMA,
                    Token = Guid.NewGuid()
                }
              ).Take(100).ToListAsync<Smscl01>();


            if (vSmsOut == null || vSmsOut.Count() == 0)
            {
                return GetIdtNotFound();
            }
            var _Smscl01Out = vSmsOut.First<Smscl01>();

            return _Smscl01Out;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        Smscl01 GetIdtNotFound()
        {
            Smscl01 _Smscl01oOut = new Smscl01
            {
                Regrdl = 0,
                DestSMS = string.Empty,
                Token = Guid.NewGuid(),
                CorpoSMS = string.Empty
            };
            return _Smscl01oOut;
        }

        [Produces("application/json")]
        [ApiExplorerSettings(IgnoreApi = false)]
        //[ApiExplorerSettings(IgnoreApi = Program.HIDE_AOUSLMO)]
        [SwaggerResponse(HttpStatusCode.OK, typeof(NoData), Description = "Successfull operation")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(NoData), Description = "Invalid Parameter supplied.")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAggSmSCL01(long id, Smscl01 item)
        {

            string[] weekDays = new string[] { "EAMSPA", "EAMSSL"};
            //using (GetAPIWEBEAMS g = new GetAPIWEBEAMS(uow))
            //{
            //    string par = string.Format("{0}.id, {1}.CodiceOut, {2}.CodiceSITO, {3}.CommessaID, {4}.Codiceimpianto", item.Id, item.CodiceOut, item.CodiceSITO, item.CommessaID, item.Codiceimpianto);
            //    g.InserisciLogStringRO(uow, "ROVIGO", "PutInsNewRdL01" + "-" + id.ToString() + " " + par, "", "");
            //}
            if (id != item.Id)
            {
                return BadRequest();
            }
            if (item.Cliente != "Engie Servizi SpA")
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    APISMS_CL01 newAPIAB = new APISMS_CL01(uow);
                    newAPIAB.ID = item.Id;
                    newAPIAB.REGRDL = item.Regrdl;
                    newAPIAB.CLIENTE = item.Cliente;
                    newAPIAB.UTENTE = item.Utente;
                    newAPIAB.TIPOLOGIASMS = item.TipologiaSMS;
                    newAPIAB.SISTEMA = item.Sistema;// da modificare
                    newAPIAB.CORPOSMS = item.CorpoSMS;
                    newAPIAB.DESTSMS = item.DestSMS;
                    newAPIAB.AREABUSINESS = item.AreaBusiness;
                    newAPIAB.CENTROCOSTO = item.CentroCosto;
                    newAPIAB.QUALITAINVIO = item.QualitaInvio; //= nd, 1 = proposto , 2 = inviato, 3 = noninviato, 
                    newAPIAB.TIPOINVIO = item.TipoInvio;
                    newAPIAB.STATO = 1; // 0 =nd, 1= proposto , 2=inviato, 3=noninviato, 
                    newAPIAB.NRINVIO = 0;                   
                    newAPIAB.DATAORAUPDATE = DateTime.Now;
                    newAPIAB.DATAORA_ULTIMOPUT = DateTime.Now;
                    newAPIAB.ISRECEIVED = false;
                    newAPIAB.ISSENT = false;
                    newAPIAB.ISCLOSED = false;
                    newAPIAB.Save();
                    uow.CommitChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }



        }
    }
}