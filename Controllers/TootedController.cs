using Microsoft.AspNetCore.Mvc;
using BohatyrovAPI.Models;
using System.Linq;
using BohatyrovAPI.Data;

namespace BohatyrovAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TootedController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TootedController(AppDbContext context)
        {
            _context = context;
        }

        // Проверить, есть ли товар у пользователя
        [HttpGet("has-toode/{kasutajaId}/{toodeId}")]
        public ActionResult<bool> HasToode(int kasutajaId, int toodeId)
        {
            var kasutajaToode = _context.KasutajaTooted
                .FirstOrDefault(kt => kt.KasutajaId == kasutajaId && kt.ToodeId == toodeId);

            return Ok(kasutajaToode != null);
        }

        // Покупка товара пользователем
        [HttpPost("osta/{id}/{kasutajaId}")]
        public IActionResult Buy(int id, int kasutajaId)
        {
            var toode = _context.Tooted.FirstOrDefault(t => t.Id == id);
            if (toode == null || !toode.IsActive)
            {
                return NotFound("Товар недоступен.");
            }

            var kasutaja = _context.Kasutajad.FirstOrDefault(k => k.Id == kasutajaId);
            if (kasutaja == null)
            {
                return NotFound("Пользователь не найден.");
            }

            // Проверка, есть ли уже товар у пользователя
            var kasutajaToode = _context.KasutajaTooted
                .FirstOrDefault(kt => kt.KasutajaId == kasutajaId && kt.ToodeId == id);

            if (kasutajaToode != null)
            {
                return BadRequest("Этот товар уже есть у пользователя.");
            }

            // Добавляем товар пользователю
            _context.KasutajaTooted.Add(new KasutajaToode
            {
                KasutajaId = kasutajaId,
                ToodeId = id
            });

            _context.SaveChanges();

            return Ok($"Пользователь {kasutaja.Eesnimi} купил {toode.Name} за {toode.Price} евро.");
        }
    }
}
