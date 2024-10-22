using Microsoft.AspNetCore.Mvc;
using BohatyrovAPI.Models;
using BohatyrovAPI.Data;
using System.Collections.Generic;
using System.Linq;

namespace BohatyrovAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KasutajaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KasutajaController(AppDbContext context)
        {
            _context = context;
        }

        // GET api/Kasutaja
        [HttpGet]
        public ActionResult<IEnumerable<Kasutaja>> GetKasutajad()
        {
            var kasutajad = _context.Kasutajad.ToList();
            return Ok(kasutajad);
        }

        // GET api/Kasutaja/{id}
        [HttpGet("{id}")]
        public ActionResult<Kasutaja> GetKasutaja(int id)
        {
            var kasutaja = _context.Kasutajad.FirstOrDefault(k => k.Id == id);
            if (kasutaja == null)
            {
                return NotFound();
            }
            return Ok(kasutaja);
        }

        // POST api/Kasutaja 
        [HttpPost]
        public ActionResult<Kasutaja> CreateKasutaja([FromBody] Kasutaja kasutaja)
        {
           
            kasutaja.Id = _context.Kasutajad.Any() ? _context.Kasutajad.Max(k => k.Id) + 1 : 1;

      
            _context.Kasutajad.Add(kasutaja);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetKasutaja), new { id = kasutaja.Id }, kasutaja);
        }

        // PUT api/Kasutaja/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateKasutaja(int id, [FromBody] Kasutaja uuendatudKasutaja)
        {
            var kasutaja = _context.Kasutajad.FirstOrDefault(k => k.Id == id);
            if (kasutaja == null)
            {
                return NotFound();
            }

            kasutaja.Kasutajanimi = uuendatudKasutaja.Kasutajanimi;
            kasutaja.Parool = uuendatudKasutaja.Parool;
            kasutaja.Eesnimi = uuendatudKasutaja.Eesnimi;
            kasutaja.Perenimi = uuendatudKasutaja.Perenimi;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/Kasutaja/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteKasutaja(int id)
        {
            var kasutaja = _context.Kasutajad.FirstOrDefault(k => k.Id == id);
            if (kasutaja == null)
            {
                return NotFound();
            }

            _context.Kasutajad.Remove(kasutaja);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
