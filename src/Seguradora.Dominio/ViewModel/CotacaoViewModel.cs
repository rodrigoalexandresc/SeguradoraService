using System;

namespace Seguradora.Dominio.ViewModel
{
    public class CotacaoViewModel
    {
        public decimal Premio { get; set; }
        public int Parcelas { get; set; }
        public decimal Valor_Parcelas { get; set; }
        public DateTime Primeiro_Vencimento { get; set; }
        public decimal Cobertura_Total { get; set; }

        public static implicit operator CotacaoViewModel(Cotacao cotacao)
        {
            return new CotacaoViewModel
            {
                Cobertura_Total = cotacao.CoberturaTotal,
                Parcelas = cotacao.Parcelas,
                Premio = cotacao.Premio,
                Primeiro_Vencimento = cotacao.PrimeiroVencimento,
                Valor_Parcelas = cotacao.ValorParcelas
            };
        }
    }
}
