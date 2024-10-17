using Microsoft.AspNetCore.Mvc;
using BohatyrovAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BohatyrovAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KasutajaController : ControllerBase
    {
        private static List<Kasutaja> kasutajad = new List<Kasutaja>
        {
            new Kasutaja(1, "sasa", "123", "Oleksandr", "Bohatyrov"),
            new Kasutaja(2, "arturi", "123", "Artur", "Šuškevitš")
        };

        [HttpGet]
        public ActionResult<IEnumerable<Kasutaja>> GetKasutajad()
        {
            return Ok(kasutajad);
        }

        [HttpGet("{id}")]
        public ActionResult<Kasutaja> GetKasutaja(int id)
        {
            var kasutaja = kasutajad.FirstOrDefault(k => k.Id == id);
            if (kasutaja == null)
            {
                return NotFound();
            }
            return Ok(kasutaja);
        }

        [HttpPost]
        public ActionResult<Kasutaja> CreateKasutaja(Kasutaja uusKasutaja)
        {
            uusKasutaja.Id = kasutajad.Count > 0 ? kasutajad.Max(k => k.Id) + 1 : 1;
            kasutajad.Add(uusKasutaja);
            return CreatedAtAction(nameof(GetKasutaja), new { id = uusKasutaja.Id }, uusKasutaja);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateKasutaja(int id, Kasutaja uuendatudKasutaja)
        {
            var kasutaja = kasutajad.FirstOrDefault(k => k.Id == id);
            if (kasutaja == null)
            {
                return NotFound();
            }

            kasutaja.Kasutajanimi = uuendatudKasutaja.Kasutajanimi;
            kasutaja.Parool = uuendatudKasutaja.Parool;
            kasutaja.Eesnimi = uuendatudKasutaja.Eesnimi;
            kasutaja.Perenimi = uuendatudKasutaja.Perenimi;

            return NoContent();
        }

     
        [HttpDelete("{id}")]
        public ActionResult DeleteKasutaja(int id)
        {
            var kasutaja = kasutajad.FirstOrDefault(k => k.Id == id);
            if (kasutaja == null)
            {
                return NotFound();
            }

            kasutajad.Remove(kasutaja);
            return NoContent();
        }
    }
}
