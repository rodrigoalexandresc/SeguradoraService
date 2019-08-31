using System.Threading.Tasks;

namespace Seguradora.Dominio.Validators
{
    public interface ICotacaoValidator
    {
        Task<bool> Validar(Seguro seguro);
    }
}
