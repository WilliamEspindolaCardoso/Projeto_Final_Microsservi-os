namespace Moradores.Dto
{
    public class MoradorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ResidenciaId { get; set; }
        public decimal Divida { get; set; }
    }

    public class CreateMoradorDto
    {
        public string Nome { get; set; }
        public int ResidenciaId { get; set; }
    }

    public class AtualizarDividaDto
    {
        public decimal NovaDivida { get; set; }
    }
}
