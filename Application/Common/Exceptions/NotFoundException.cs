namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public string errorMessage {  get; set; }
        public int? errorCode {  get; set; }
        public NotFoundException(string message, int? code = 404) : base(message)
        {
            errorMessage = message;
            if (code != null)
                errorCode = code.Value;
        }
    }
}
