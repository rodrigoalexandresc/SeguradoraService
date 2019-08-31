using Seguradora.Dominio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seguradora.Dominio.Validators
{
    public class CotacaoValidator : ICotacaoValidator
    {
        readonly IServicoDeNotificacao servicoDeNotificacao;
        readonly IdadeValidator idadeValidator;
        readonly CidadeValidator cidadeValidator;
        readonly CEPValidator cEPValidator;
        readonly CoberturasValidator coberturasValidator;

        public CotacaoValidator(IServicoDeNotificacao servicoDeNotificacao,
            IdadeValidator idadeValidator,
            CidadeValidator cidadeValidator,
            CEPValidator cEPValidator,
            CoberturasValidator coberturasValidator)
        {
            this.servicoDeNotificacao = servicoDeNotificacao;
            this.idadeValidator = idadeValidator;
            this.cidadeValidator = cidadeValidator;
            this.cEPValidator = cEPValidator;
            this.coberturasValidator = coberturasValidator;
        }

        public async Task<bool> Validar(Seguro seguro)
        {
            ValidarENotificar(new List<Func<ValidationResult>>
            {
                () => idadeValidator.Validar(seguro.CalcularIdadeSegurado()),
                () => cEPValidator.Validar(seguro.Endereco.CEP),
                () => coberturasValidator.Validar(seguro)
            });

            await ValidarCidade(seguro);

            return !(servicoDeNotificacao.Notificacoes.Any());
        }

        private async Task ValidarCidade(Seguro seguro)
        {
            var validacaoCidade = await cidadeValidator.Validar(seguro.Endereco.Cidade);
            if (!validacaoCidade.IsValid) servicoDeNotificacao.PostarNotificacao(validacaoCidade.Message);
        }

        private void ValidarENotificar(IEnumerable<Func<ValidationResult>> validacoes)
        {
            foreach (var validacao in validacoes)
            {
                var resultado = validacao();
                if (!resultado.IsValid)
                    servicoDeNotificacao.PostarNotificacao(resultado.Message);
            }

        }
    }
}
