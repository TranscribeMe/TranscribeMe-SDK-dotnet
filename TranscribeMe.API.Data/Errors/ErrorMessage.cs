namespace TranscribeMe.API.Data.Errors
{
    public class ErrorMessage : IErrorMessage
    {
        public ErrorMessage()
        {
        }

        public ErrorMessage(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}