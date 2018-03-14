using System.Collections.Generic;

namespace TranscribeMe.API.Data
{
    public class BatchEntitiesOperationModel
    {
        public BatchEntitiesOperationModel()
        {
            Ids = new List<string>();
        }

        public IList<string> Ids { get; set; }
    }
}