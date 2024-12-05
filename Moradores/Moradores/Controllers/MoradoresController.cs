using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Moradores.Models;

namespace Moradores.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoradoresController : ControllerBase
    {
        private readonly MoradoresContext _context;

        public MoradoresController(MoradoresContext context)
        {
            _context = context;
        }

        // Obter um morador pelo ID
        [HttpGet("{id}")]
        public IActionResult GetMorador(int id)
        {
            var morador = _context.Moradores.Find(id);
            if (morador == null)
                return NotFound();
            return Ok(morador);
        }

        // Criar um novo morador
        [HttpPost]
        public IActionResult CreateMorador([FromBody] Morador morador)
        {
            _context.Moradores.Add(morador);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMorador), new { id = morador.Id }, morador);
        }

        // Atualizar dívida do morador
        [HttpPut("{id}/divida")]
        public IActionResult AtualizarDivida(int id, [FromBody] decimal novaDivida)
        {
            var morador = _context.Moradores.Find(id);
            if (morador == null)
                return NotFound();

            morador.Divida += novaDivida;
            _context.SaveChanges();
            return Ok(morador);
        }
    }
}
