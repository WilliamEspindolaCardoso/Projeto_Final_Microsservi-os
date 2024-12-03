namespace Taxas.Models
{
    public class Taxa
    {
        public int Id { get; set; }
        public int ResidenciaId { get; set; }
        public decimal Valor { get; set; }
    }
}
