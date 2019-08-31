using Seguradora.Dominio;
using Seguradora.Dominio.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Seguradora.Repository
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly HttpClient _client;
        private readonly string URIValidacao;

        private IEnumerable<Cidade> cidadeDataSetCache;

        private async Task<IEnumerable<Cidade>> ObterDataSet()
        {
            if (cidadeDataSetCache == null)
            {
                var response = await _client.GetAsync(URIValidacao);
                if (response != null && response.IsSuccessStatusCode)
                {
                    var citiesResponse = await response.Content.ReadAsAsync<CitiesResult>();
                    cidadeDataSetCache = citiesResponse.Cities.Select(r => new Cidade { Nome = r.Name });
                }
            }
            return cidadeDataSetCache;
        }

        public CidadeRepository()
        {
            this._client = new HttpClient();
            URIValidacao = "https://www.redesocialdecidades.org.br/cities";
        }

        public async Task<bool> Existe(string nome)
        {
            var cidades = await ObterDataSet();
            if (cidades != null)
                return cidades.Any(o => o.Nome.ToLower() == nome.ToLower());

            return false;
        }

        private class CitiesResult
        {
            public IEnumerable<City> Cities { get; set; }
        }

        private class City
        {
            public string Name { get; set; }
        }
    }
}
