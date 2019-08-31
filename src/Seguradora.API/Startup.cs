using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seguradora.Dominio;
using Seguradora.Dominio.Repository;
using Seguradora.Dominio.Services;
using Seguradora.Dominio.Validators;
using Seguradora.Repository;

namespace Seguradora.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICoberturaRepository, CoberturaRepository>();
            services.AddScoped<ICalculadoraSeguro, CalculadoraSeguro>();
            services.AddScoped<ICotacaoValidator, CotacaoValidator>();
            services.AddScoped<IdadeValidator>();
            services.AddScoped<CEPValidator>();
            services.AddScoped<CidadeValidator>();
            services.AddScoped<CoberturasValidator>();
            services.AddScoped<IServicoDeNotificacao, ServicoDeNotificacao>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
