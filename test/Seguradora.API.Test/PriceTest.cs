using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Seguradora.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Seguradora.API.Test
{
    public class PriceTest
    {
        private readonly HttpClient _client;

        public PriceTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
                
        }

        [Fact]
        public async Task PostTest()
        {

            var dadosSeguro = new DadosSeguroViewModel
            {
                Nome = "Rodrigo Alexandre",
                Nascimento = new DateTime(1986,10,28),
                Endereco = new EnderecoViewModel
                {
                    Bairro = "Triunfo",
                    CEP = "13387-676",
                    Cidade = "Campinas",
                    Logradouro = "Rua JBA"
                },
                Coberturas = new List<int> { 1, 2, 3, 4 }
            };
            
            var response = await _client.PostAsJsonAsync("/api/Price", dadosSeguro);

            response.EnsureSuccessStatusCode();
            var cotacaoViewModel = await response.Content.ReadAsAsync<CotacaoViewModel>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
