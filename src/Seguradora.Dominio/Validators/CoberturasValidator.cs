using System.Linq;

namespace Seguradora.Dominio.Validators
{
    public class CoberturasValidator
    {
        public ValidationResult Validar(Seguro seguro)
        {
            if (seguro.Coberturas == null || (seguro.Coberturas != null && seguro.Coberturas.Count(c => c.Principal) == 0))
                return new ValidationResult(false, "Necessário selecionar uma cobertura obrigatória");

            if (seguro.Coberturas != null && seguro.Coberturas.Count() > 4)
                return new ValidationResult(false, "Máximo de 4 coberturas para cotação");

            return new ValidationResult(true);
        }
    }
}
