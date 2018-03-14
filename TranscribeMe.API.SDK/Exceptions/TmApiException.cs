using System;
using System.Net;

namespace TranscribeMe.API.SDK.Exceptions
{
    public class TmApiException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public string[] Errors { get; private set; }

        public TmApiException(HttpStatusCode statusCode, string[] errors, string content)
            : base(content)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}