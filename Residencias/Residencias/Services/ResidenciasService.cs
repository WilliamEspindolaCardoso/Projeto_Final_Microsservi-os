using System.Text.Json;
using Residencias.Models;

namespace Residencias.Services
{
    public class ResidenciasService
    {
        private readonly ResidenciasContext _context;

        public ResidenciasService(ResidenciasContext context)
        {
            _context = context;
        }

        // Obter uma residência pelo ID
        public Residencia GetResidenciaById(int id)
        {
            return _context.Residencias.Find(id);
        }

        // Criar uma nova residência
        public Residencia CreateResidencia(Residencia residencia)
        {
            _context.Residencias.Add(residencia);
            _context.SaveChanges();
            return residencia;
        }
    }
}
