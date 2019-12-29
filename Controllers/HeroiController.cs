using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCpre.Dominio;
using EFCpre.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCpre.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly HeroiContext _context;
        public HeroiController(HeroiContext context)
        {
            _context = context;
        }

        // GET: api/Heroi
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Heroi/5
        [HttpGet("{id}", Name = "GetHeroi")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Heroi
        [HttpPost]
        public ActionResult Post(Heroi model)
        {
            try
            {
                //var heroi = new Heroi
                //{
                //    Nome = "Homem de Ferro",
                //    Armas = new List<Arma>
                //    {
                //        new Arma { Nome = "Mac 3" },
                //        new Arma { Nome = "Mac 5" }
                //    }
                //};

                _context.Herois.Add(model);
                _context.SaveChanges();

                return Ok("Bazinga");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT: api/Heroi/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Heroi model)
        {
            try
            {
                //var heroi = new Heroi
                //{
                //    Id = id,
                //    Nome = "Iron Man",
                //    Armas = new List<Arma>
                //    {
                //        new Arma { Id = 0, Nome = "Mark III" },
                //        new Arma { Id = 1, Nome = "Mark V" }
                //    }
                //};

                if (_context.Herois.AsNoTracking().FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Update(model);
                    _context.SaveChanges();

                    return Ok("Bazinga");
                }

                return Ok("Nao Encontrado!");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
