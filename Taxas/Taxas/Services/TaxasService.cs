using System.Text.Json;
using Taxas.Models;

namespace Taxas.Services
{
    public class TaxasService
    {
        private readonly TaxasContext _context;
        private readonly HttpClient _httpClient;

        public TaxasService(TaxasContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        // Obter uma taxa pelo ID
        public Taxa GetTaxaById(int id)
        {
            return _context.Taxas.Find(id);
        }

        // Criar uma nova taxa
        public async Task<Taxa> CreateTaxa(Taxa taxa)
        {
            // Valida se a residência está ativa
            var response = await _httpClient.GetAsync($"https://localhost:7160/api/Residencias/{taxa.ResidenciaId}");
            if (!response.IsSuccessStatusCode)
                throw new Exception("Residência não encontrada ou inativa.");

            var residencia = JsonSerializer.Deserialize<Residencia>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (residencia == null || !residencia.Ativa)
                throw new Exception("Residência não está ativa.");

            // Salva a taxa no banco de dados
            _context.Taxas.Add(taxa);
            _context.SaveChanges();

            // Atualiza a dívida do morador
            var updateResponse = await _httpClient.PutAsJsonAsync(
                $"https://localhost:7107/api/Moradores/{taxa.ResidenciaId}/divida",
                taxa.Valor);

            if (!updateResponse.IsSuccessStatusCode)
                throw new Exception("Falha ao atualizar a dívida do morador.");

            return taxa;
        }
    }

    public class Residencia
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public bool Ativa { get; set; }
    }
}