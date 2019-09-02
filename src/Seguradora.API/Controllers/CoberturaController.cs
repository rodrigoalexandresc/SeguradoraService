using Microsoft.AspNetCore.Mvc;
using Seguradora.Dominio.Repository;
using Seguradora.Dominio.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace Seguradora.API.Controllers
{

    [Produces("application/json")]
    [Route("api/Cobertura")]
    public class CoberturaController : Controller
    {
        readonly ICoberturaRepository coberturaRepository;
        public CoberturaController(ICoberturaRepository coberturaRepository)
        {
            this.coberturaRepository = coberturaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var coberturas = await coberturaRepository.Obter();
            var coberturasViewModel = coberturas.Select(c => (CoberturaViewModel)c);
            return Ok(await coberturaRepository.Obter());
        }
    }
}
