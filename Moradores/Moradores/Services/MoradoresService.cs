using System.Text.Json;
using Moradores.Models;

namespace Moradores.Services
{
    public class MoradoresService
    {
        private readonly MoradoresContext _context;

        public MoradoresService(MoradoresContext context)
        {
            _context = context;
        }

        // Obter um morador pelo ID
        public Morador GetMoradorById(int id)
        {
            return _context.Moradores.Find(id);
        }

        // Criar um novo morador
        public Morador CreateMorador(Morador morador)
        {
            _context.Moradores.Add(morador);
            _context.SaveChanges();
            return morador;
        }

        // Atualizar dívida do morador
        public Morador AtualizarDivida(int id, decimal valor)
        {
            var morador = _context.Moradores.Find(id);
            if (morador != null)
            {
                morador.Divida += valor;
                _context.SaveChanges();
            }
            return morador;
        }
    }
}