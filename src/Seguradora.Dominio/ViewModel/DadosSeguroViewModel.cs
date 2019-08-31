using System;
using System.Collections.Generic;

namespace Seguradora.Dominio.ViewModel
{
    public class DadosSeguroViewModel
    {
        public string Nome { get; set; }
        public DateTime? Nascimento { get; set; }
        public EnderecoViewModel Endereco { get; set; }
        public IEnumerable<int> Coberturas { get; set; }

        public static implicit operator Seguro(DadosSeguroViewModel viewModel)
        {
            return new Seguro
            {
                Nome = viewModel.Nome,
                Nascimento = viewModel.Nascimento ?? DateTime.MinValue,
                Endereco = viewModel.Endereco,
                IdsCoberturas = viewModel.Coberturas
            };
        }
    }
}
