using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevExpress.Xpo;
using ApiAuth.Models;
using APIAuth.Database;
using NSwag.Annotations;
using System.Net;

namespace ApiAuth.Controllers
{
    public class K0e7yT4O3k2 : Controller
    {
        private UnitOfWork uow;
        public K0e7yT4O3k2(UnitOfWork uow) // nuovo
        {
            this.uow = uow;
        }

        [Produces("application/json")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpGet("{Utente}")]
        public async Task<ActionResult<Aut>> Get(string Utente, string Password, string Sistema)
        {
            Guid _Guid = Guid.NewGuid();
            //controllo utenti e password decrittazione di entrambi
            //aggiornamento token su tabella APIAUT

            List<APIAUT> RR = null;

            RR = await uow.Query<APIAUT>()
                .Where(w => w.utente == Utente)
                .Where(w => w.password == Password)
                .Where(w => w.sistema == Sistema)
                .ToListAsync()
                ;
            int Conto = RR.Count();
            if (Conto == 0)
                return BadRequest();
            else
            {
                APIAUT UpdAPIAUT = await uow.Query<APIAUT>()
                            .Where(w => w.utente == Utente)
                            .Where(w => w.password == Password)
                            .Where(w => w.sistema == Sistema)
                        .FirstOrDefaultAsync<APIAUT>();
                UpdAPIAUT.token = _Guid;
                UpdAPIAUT.Save();
                uow.CommitChanges();
            }

            var TokOut = await uow.Query<APIAUT>()
                .Where(w => w.utente == Utente)
                .Where(w => w.password == Password)
                .Where(w => w.sistema == Sistema)
                .Select(s => new
          Aut
                { 
                    Token = _Guid
                }
              ).Take(100).ToListAsync<Aut>();
         
            var _TokOut = TokOut.First<Aut>();

            return _TokOut;
        }

        //[ApiExplorerSettings(IgnoreApi = true)]
        //Smscl01 GetIdtNotFound()
        //{
        //    Smscl01 _Smscl01oOut = new Smscl01
        //    {
        //        Regrdl = 0,
        //        DestSMS = string.Empty,
        //        Token = Guid.NewGuid(),
        //        CorpoSMS = string.Empty
        //    };
        //    return _Smscl01oOut;
        //}

    }
}
