namespace Batonezas.WebApi.Infrastructure
{
    public class ErrorInfo
    {
        public string PropertyName { get; private set; }
        public string ErrorMessage { get; private set; }

        public ErrorInfo(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}