using Seguradora.Dominio.Repository;
using Seguradora.Dominio.Services;
using Seguradora.Dominio.Validators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seguradora.Dominio
{
    public class CalculadoraSeguro : ICalculadoraSeguro
    {
        readonly ICoberturaRepository coberturaRepository;
        readonly ICotacaoValidator cotacaoValidator;

        public CalculadoraSeguro(ICoberturaRepository coberturaRepository,
            ICotacaoValidator cotacaoValidator)
        {
            this.coberturaRepository = coberturaRepository;
            this.cotacaoValidator = cotacaoValidator;
        }

        public async Task<Cotacao> Calcular(Seguro seguro)
        {
            seguro.Coberturas = await coberturaRepository.Obter(seguro.IdsCoberturas);
            var cotacao = new Cotacao(seguro);

            if (await cotacaoValidator.Validar(seguro))
            {
                cotacao.Calcular();
            }
           
            return cotacao;
        }
    }
}
