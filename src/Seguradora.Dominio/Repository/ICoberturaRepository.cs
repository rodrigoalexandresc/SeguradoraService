using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seguradora.Dominio.Repository
{
    public interface ICoberturaRepository
    {
        Task<IEnumerable<Cobertura>> Obter(IEnumerable<int> idsCoberturas);
        Task<IEnumerable<Cobertura>> Obter();
    }
}
