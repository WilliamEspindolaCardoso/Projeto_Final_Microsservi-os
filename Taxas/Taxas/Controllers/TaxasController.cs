using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Taxas.Models;

namespace Taxas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxasController : ControllerBase
    {
        private readonly TaxasContext _context;
        private readonly HttpClient _httpClient;

        public TaxasController(TaxasContext context)
        {
            _context = context;
            _httpClient = new HttpClient();
        }

        // Cadastrar uma nova taxa
        [HttpPost]
        public async Task<IActionResult> CreateTaxa([FromBody] Taxa taxa)
        {
            // Valida se a residência está ativa
            var response = await _httpClient.GetAsync($"https://localhost:7160/api/Residencias/{taxa.ResidenciaId}");
            if (!response.IsSuccessStatusCode)
                return BadRequest("Residência não encontrada ou inativa.");

            var residencia = JsonSerializer.Deserialize<Residencia>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (residencia == null || !residencia.Ativa)
                return BadRequest("Residência não está ativa.");

            // Registra a taxa
            _context.Taxas.Add(taxa);
            _context.SaveChanges();

            // Atualiza a dívida do morador
            await _httpClient.PutAsJsonAsync($"https://localhost:7107/api/Moradores/{residencia.Id}/divida", taxa.Valor);

            return CreatedAtAction(nameof(GetTaxa), new { id = taxa.Id }, taxa);
        }

        // Obter uma taxa pelo ID
        [HttpGet("{id}")]
        public IActionResult GetTaxa(int id)
        {
            var taxa = _context.Taxas.Find(id);
            if (taxa == null)
                return NotFound("ID não encontrado");
            return Ok(taxa);
        }
    }

    public class Residencia
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public bool Ativa { get; set; }
    }
}
