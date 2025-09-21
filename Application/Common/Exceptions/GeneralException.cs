namespace Application.Common.Exceptions
{
    public class GeneralException : Exception
    {
        public string? InnerMessage { get; set; }
        public int? ResultCode { get; set; }
    }
}