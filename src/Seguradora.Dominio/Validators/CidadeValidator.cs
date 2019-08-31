using Seguradora.Dominio.Repository;
using System.Threading.Tasks;

namespace Seguradora.Dominio.Validators
{
    public class CidadeValidator
    {
        private readonly ICidadeRepository cidadeRepository;

        public CidadeValidator(ICidadeRepository cidadeRepository)
        {
            this.cidadeRepository = cidadeRepository;    
        }

        public async Task<ValidationResult> Validar(string cidade)
        {
            if (await cidadeRepository.Existe(cidade))
                return new ValidationResult(true);

            return new ValidationResult(false, "Cidade não encontrada");
        }
    }

}
