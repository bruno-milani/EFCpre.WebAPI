using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCpre.Dominio;
using EFCpre.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCpre.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly HeroiContext _context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, HeroiContext Context)
        {
            _logger = logger;
            _context = Context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{nameHero}")]
        public ActionResult InsertHero(string nameHero)
        {
            try
            {
                var heroi = new Heroi { Nome = nameHero };

                _context.Herois.Add(heroi);
                _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }

        [HttpGet("Filtro/{Id}")]
        public ActionResult GetIdHero(int Id)
        {
            var listHeroi = _context.Herois
                                    .Where(h => h.Id == Id)
                                    .ToList();

            return Ok(listHeroi);
        }

        [HttpGet("Delete/{Id}")]
        public ActionResult DeleteHero(int Id)
        {
            var Heroi = _context.Herois
                                .Where(h => h.Id == Id)
                                .SingleOrDefault();

            _context.Herois.Remove(Heroi);
            _context.SaveChangesAsync();

            return Ok();
        }
    }
}
