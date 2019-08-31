using Seguradora.Dominio.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Seguradora.Dominio.Test
{
    public class CotacaoTest
    {
        private Seguro seguro = new Seguro
        {
            Nome = "Rodrigo Alexandre",
            Nascimento = new DateTime(1986, 10, 28),
            Endereco = new Endereco
            {
                Bairro = "Triunfo",
                CEP = "13387-676",
                Cidade = "Nova Odessa",
                Logradouro = "Rua JBA"
            },
            Coberturas = new List<Cobertura>
                {
                    new Cobertura { Id = 1, Nome = "Morte Acidental", Premio = 100, Principal = true, Valor = 50000 },
                    new Cobertura { Id = 2, Nome = "Quebra de Ossos", Premio = 30, Principal = false, Valor = 5000 },
                    new Cobertura { Id = 3, Nome = "Internação Hospitalar", Premio = 50, Principal = false, Valor = 10000 },
                }
        };

        [Fact]
        public void CoberturaTotalTest()
        {
            Cotacao cotacao = CotacaoCalculada();
            Assert.Equal(65000, cotacao.CoberturaTotal);
        }

        [Theory]
        [InlineData(31)]
        [InlineData(40)]
        [InlineData(45)]
        public void Premio31Ate45AnosTest(int idadeSegurado)
        {
            seguro.Nascimento = DateTime.Now.AddYears(-idadeSegurado);
            Cotacao cotacao = CotacaoCalculada();
            var subTotal = seguro.Coberturas.Sum(s => s.Premio);
            var fator = 0.02m * (idadeSegurado - 31);
            Assert.Equal(subTotal * (1 - fator), cotacao.Premio);
        }

        [Theory]
        [InlineData(18)]
        [InlineData(25)]
        [InlineData(30)]
        public void Premio30Ate18AnosTest(int idadeSegurado)
        {
            seguro.Nascimento = DateTime.Now.AddYears(-idadeSegurado);
            Cotacao cotacao = CotacaoCalculada();
            var subTotal = seguro.Coberturas.Sum(s => s.Premio);
            var fator = 0.08m * (idadeSegurado - 30);
            Assert.Equal(subTotal * (1 + fator), cotacao.Premio);
        }

        [Fact]
        public void PremioAcima45AnosTest()
        {
            seguro.Nascimento = DateTime.Now.AddYears(-46);
            Cotacao cotacao = CotacaoCalculada();
            var subTotal = seguro.Coberturas.Sum(s => s.Premio);
            Assert.Equal(subTotal, cotacao.Premio);
        }

        [Theory]
        [InlineData(1, 500)]
        [InlineData(2, 1000)]
        [InlineData(3, 2000)]
        [InlineData(4, 2001)]
        public void NumeroParcelasTest(int numeroParcelas, decimal valorPremio)
        {
            seguro.Nascimento = DateTime.Now.AddYears(-46); //forçar prêmio 100%
            seguro.Coberturas = new List<Cobertura>
            {
                new Cobertura { Id = 1, Nome = "Morte Acidental", Premio = valorPremio, Principal = true, Valor = 50000 }
            };
            Cotacao cotacao = CotacaoCalculada();
            Assert.Equal(numeroParcelas, cotacao.Parcelas);
        }

        [Fact]
        public void DiaVencimentoTest()
        {
            var proximoMes = DateTime.Now.AddMonths(1);
            Cotacao cotacao = CotacaoCalculada();
            Assert.Equal(proximoMes.RetornaQuintoDiaUtil(), cotacao.PrimeiroVencimento);
        }

        private Cotacao CotacaoCalculada()
        {
            var cotacao = new Cotacao(seguro);
            cotacao.Calcular();
            return cotacao;
        }


    }
}
