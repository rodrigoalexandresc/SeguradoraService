namespace Seguradora.Dominio
{
    public class Cobertura
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Premio { get; set; }
        public decimal Valor { get; set; }
        public bool Principal { get; set; }
    }
}
