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
    public class BatalhaController : ControllerBase
    {
        private readonly HeroiContext _context;
        public BatalhaController(HeroiContext context)
        {
            _context = context;
        }

        // GET: api/Batalha
        [HttpGet]
        public ActionResult GetBatalha()
        {
            try
            {
                var list = _context.Batalhas.ToList();

                return Ok(list);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Batalha/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public string GetId(int id)
        {
            return "value";
        }

        // POST: api/Batalha
        [HttpPost]
        public ActionResult PostBatalha(Batalha batalha)
        {
            try
            {
                _context.Batalhas.Add(batalha);
                _context.SaveChanges();

                return Ok("Saved");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT: api/Batalha/5
        [HttpPut("{id}")]
        public ActionResult PutBatalha(int id, Batalha batalha)
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

                if (_context.Batalhas.AsNoTracking().FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Update(batalha);
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
        public void DeleteBatalha(int id)
        {
        }
    }
}
