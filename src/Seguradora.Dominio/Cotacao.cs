using Seguradora.Dominio.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seguradora.Dominio
{
    public class Cotacao
    {
        public decimal Premio { get; private set; }
        public int Parcelas { get; private set; }                
        public decimal CoberturaTotal { get; private set; }
        public DateTime PrimeiroVencimento { get; private set; }
        public decimal ValorParcelas { get; private set; }

        readonly Seguro seguro;

        public Cotacao(Seguro seguro)
        {
            this.seguro = seguro;
            this.PrimeiroVencimento = CalcularPrimeiroVencimento();
        }

        public void Calcular()
        {
            Premio = CalcularPremio(seguro);
            CoberturaTotal = seguro.CalcularTotalCoberturas();
            Parcelas = CalcularNumeroParcelas(Premio);
            ValorParcelas = CalcularValorParcelas();
        }

        private decimal CalcularValorParcelas() => Math.Round(Premio / Parcelas, 2);

        private DateTime CalcularPrimeiroVencimento()
        {
            var proximoMes = DateTime.Now.AddMonths(1);

            return proximoMes.RetornaQuintoDiaUtil();
        }

        private int CalcularNumeroParcelas(decimal premio)
        {
            if (premio <= 500) return 1;
            if (premio > 500 && premio <= 1000) return 2;
            if (premio > 1000 && premio <= 2000) return 3;
            if (premio > 2000) return 4;
            return 0;

        }

        private decimal CalcularPremio(Seguro seguro)
        {
            var subTotal = CalcularSubTotal(seguro.Coberturas);            
            var percentualDoPremioIdade = CalcularPercentualPremioIdade();
            return subTotal * percentualDoPremioIdade;
        }

        private decimal CalcularPercentualPremioIdade()
        {
            var idadeSegurado = seguro.CalcularIdadeSegurado();

            if (idadeSegurado >= 18 && idadeSegurado <= 30)
            {
                var fator = 0.08m * (idadeSegurado - 30);
                return (1 + fator);
            }

            if (idadeSegurado >= 30 && idadeSegurado <= 45)
            {
                var fator = 0.02m * (idadeSegurado - 31);
                return (1 - fator);
            }

            return 1m;
        }

        private decimal CalcularSubTotal(IEnumerable<Cobertura> coberturas) => coberturas?.Sum(c => c.Premio) ?? 0m;
    }
}
