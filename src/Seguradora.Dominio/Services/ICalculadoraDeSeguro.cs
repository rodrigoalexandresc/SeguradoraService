using System.Threading.Tasks;

namespace Seguradora.Dominio.Services
{
    public interface ICalculadoraSeguro
    {
        Task<Cotacao> Calcular(Seguro seguro);
    }
}
