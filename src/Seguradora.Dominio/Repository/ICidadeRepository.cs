using System.Threading.Tasks;

namespace Seguradora.Dominio.Repository
{
    public interface ICidadeRepository
    {
        Task<bool> Existe(string nome);
    }
}
