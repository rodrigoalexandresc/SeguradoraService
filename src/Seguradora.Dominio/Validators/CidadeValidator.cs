using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Seguradora.Dominio.Validators
{
    public class CidadeValidator
    {
        private readonly HttpClient _client;
        private readonly string URIValidacao;

        public CidadeValidator()
        {
            this._client = new HttpClient();
            URIValidacao = "https://www.redesocialdecidades.org.br/cities";
        }

        public async Task<ValidationResult> Validar(string cidade)
        {
            var response = await _client.GetAsync(URIValidacao);
            if (response != null && response.IsSuccessStatusCode)
            {
                var citiesResponse = await response.Content.ReadAsAsync<CitiesResult>();
                if (citiesResponse != null && citiesResponse.Cities.Any(c => c.Name.ToLower() == cidade.ToLower()))
                    return new ValidationResult(true);
            }
            return new ValidationResult(false, "Cidade não encontrada");
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
