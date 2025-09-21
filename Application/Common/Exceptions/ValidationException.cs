namespace Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public string[] errorCodes { get; set; }
        public string[] errorMembers { get; set; }
        public string? entityName { get; set; }
        public ValidationException(string[] codes) : base()
        {
            errorCodes = codes;
        }
    }
}
