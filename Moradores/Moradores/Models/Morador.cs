namespace Moradores.Models
{
    public class Morador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ResidenciaId { get; set; }
        public decimal Divida { get; set; }
    }
}
