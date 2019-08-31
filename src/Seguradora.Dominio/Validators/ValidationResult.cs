namespace Seguradora.Dominio.Validators
{
    public class ValidationResult
    {
        public ValidationResult(bool isValid, string message = "")
        {
            IsValid = isValid;
            Message = message;
        }

        public bool IsValid { get; private set; }
        public string Message { get; private set; }
    }
}
