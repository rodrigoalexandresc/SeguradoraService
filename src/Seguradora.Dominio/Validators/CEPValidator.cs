namespace Seguradora.Dominio.Validators
{
    public class CEPValidator
    {
        public ValidationResult Validar(string CEP)
        {
            if (CEP.Replace("-", "").Length != 8)
                return new ValidationResult(false, "CEP inválido");

            return new ValidationResult(true);
        }
    }

}
