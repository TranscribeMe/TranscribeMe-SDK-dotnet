using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data
{
    public class UserActivateModel
    {
        [Required, Url]
        public string UserSignInUrl { get; set; }
    }
}