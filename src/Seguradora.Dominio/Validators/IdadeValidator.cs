namespace Seguradora.Dominio.Validators
{
    public class IdadeValidator
    {
        public ValidationResult Validar(int idade)
        {
            if (idade <= 18)
                return new ValidationResult(false, "Não é permitido contratante menor de 18 anos");
            return new ValidationResult(true);
        }
    }
}
