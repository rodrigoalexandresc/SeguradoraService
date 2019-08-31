using Microsoft.AspNetCore.Mvc;
using Seguradora.Dominio.Services;
using Seguradora.Dominio.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace Seguradora.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Price")]
    public class PriceController : Controller
    {
        readonly ICalculadoraSeguro calculadoraSeguro;
        readonly IServicoDeNotificacao servicoDeNotificacao;

        public PriceController(ICalculadoraSeguro calculadoraSeguro, IServicoDeNotificacao servicoDeNotificacao)
        {
            this.calculadoraSeguro = calculadoraSeguro;
            this.servicoDeNotificacao = servicoDeNotificacao;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] DadosSeguroViewModel viewModel)
        {
            CotacaoViewModel cotacao = await calculadoraSeguro.Calcular(viewModel);
            if (servicoDeNotificacao.Notificacoes.Any())
            {
                return BadRequest(servicoDeNotificacao.Notificacoes);
            }
            return Ok(cotacao);
        }
    }
}