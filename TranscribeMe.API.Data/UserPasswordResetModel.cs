using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data
{
    public class UserPasswordResetModel
    {
        [Required, Url]
        public string ResetPasswordUrl { get; set; }
    }
}
