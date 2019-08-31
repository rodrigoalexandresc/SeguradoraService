namespace Seguradora.Dominio.ViewModel
{
    public class EnderecoViewModel
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }

        public static implicit operator Endereco(EnderecoViewModel viewModel)
        {
            return new Endereco
            {
                Bairro = viewModel.Bairro,
                CEP = viewModel.CEP,
                Cidade = viewModel.Cidade,
                Logradouro = viewModel.Logradouro
            };
        }
    }
}
