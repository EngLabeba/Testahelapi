namespace Application.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public string errorMessage { get; set; }
        public string? errorCode { get; set; }
        public string? entityName { get; set; }
        public int? resultCode { get; set; }
        public BusinessException(Exception exception, string? code, string? entityName, int? result = -1) : base(null, exception)
        {
            errorMessage = string.Format(
                GetType().Name + " \n" +
                "message: " + exception.Message + " \n" +
                "inner exception: " + Convert.ToString(exception.InnerException) + " \n" +
                "stacktrace: " + Convert.ToString(exception.StackTrace) + " \n");

            this.entityName = entityName;
            if (result != null)
                resultCode = result;
            else
                resultCode = -1;

            if (code != null)
                errorCode = code;
            else
                errorCode = "general";
        }
        public BusinessException() : base()
        {
            errorMessage = "BusinessException";
            errorCode = "general";
        }
    }
}
