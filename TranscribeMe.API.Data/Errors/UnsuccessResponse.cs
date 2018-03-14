using System.Collections.Generic;

namespace TranscribeMe.API.Data.Errors
{
    public class UnsuccessResponse
    {
        public IList<IErrorMessage> Messages { get; set; }
    }
}