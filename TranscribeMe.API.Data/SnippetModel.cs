using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data
{
    public class SnippetModel 
    {
        [Required]
        public string Shortcut { get; set; }

        [Required]
        public string Text { get; set; }
    }
}