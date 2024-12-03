namespace Taxas.Dto
{
    public class TaxaDto
    {
        public int Id { get; set; }
        public int ResidenciaId { get; set; }
        public decimal Valor { get; set; }
    }

    public class CreateTaxaDto
    {
        public int ResidenciaId { get; set; }
        public decimal Valor { get; set; }
    }
}