namespace Seguradora.Dominio.ViewModel
{
    public class CoberturaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public static implicit operator CoberturaViewModel(Cobertura cobertura)
        {
            return new CoberturaViewModel
            {
                Id = cobertura.Id,
                Descricao = cobertura.Nome
            };

        }
    }
}
