using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Residencias.Models;

namespace Residencias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResidenciasController : ControllerBase
    {
        private readonly ResidenciasContext _context;

        public ResidenciasController(ResidenciasContext context)
        {
            _context = context;
        }

        // Obter uma residência pelo ID
        [HttpGet("{id}")]
        public IActionResult GetResidencia(int id)
        {
            var residencia = _context.Residencias.Find(id);
            if (residencia == null)
                return NotFound();
            return Ok(residencia);
        }

        // Criar uma nova residência
        [HttpPost]
        public IActionResult CreateResidencia([FromBody] Residencia residencia)
        {
            _context.Residencias.Add(residencia);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetResidencia), new { id = residencia.Id }, residencia);
        }
    }
}
