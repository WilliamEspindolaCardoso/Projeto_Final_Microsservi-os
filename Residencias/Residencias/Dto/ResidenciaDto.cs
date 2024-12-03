namespace Residencias.Dto
{
    public class ResidenciaDto
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public bool Ativa { get; set; }
    }

    public class CreateResidenciaDto
    {
        public string Numero { get; set; }
        public bool Ativa { get; set; }
    }
}
