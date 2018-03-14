using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data
{
    public class FolderModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}