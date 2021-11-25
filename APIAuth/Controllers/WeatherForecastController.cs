//using APIAuth.Database;
using ApiAuth.Models;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAuth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private UnitOfWork uow;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}
        public WeatherForecastController(UnitOfWork uow)
        {
            this.uow = uow;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<NewRdLID>>> Get()
        //{
        //    var MIO= "NNNNN";
        //    var vnewRdL = await uow.Query<TICKET>() 
        //     .Where(w => w.Oid > 17946)
        //    .Select(s => new    NewRdLID
        //    { Id = s.Oid }
        //  ).ToListAsync<NewRdLID>();              //.AsEnumerable< NewRdL>();
        //    var MIO1= "FFF";

        //    return vnewRdL;
        //}


    }
}
