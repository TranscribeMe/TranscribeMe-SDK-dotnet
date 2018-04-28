using System;

namespace TranscribeMe.API.SDK.Exceptions
{
    public class TmSdkServiceException : Exception
    {
        public TmSdkServiceException(string message) : base(message)
        {
        }
    }
}