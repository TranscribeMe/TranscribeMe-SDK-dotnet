using System.Collections.Generic;

namespace TranscribeMe.API.Data.Integrations
{
    public class FilesImportModel
    {
        public FilesImportModel()
        {
            Files = new List<string>();
        }

        public IList<string> Files { get; set; }
    }
}