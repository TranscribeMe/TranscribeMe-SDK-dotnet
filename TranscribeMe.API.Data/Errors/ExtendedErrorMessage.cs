using System.Collections.Generic;

namespace TranscribeMe.API.Data.Errors
{
    public class ExtendedErrorMessage : IErrorMessage
    {
        public ExtendedErrorMessage()
        {
        }

        public ExtendedErrorMessage(string message)
        {
            Message = message;
        }

        public string Message { get; set; }

        public string Type { get; set; }

        public ICollection<object> Data { get; set; }
    }
}