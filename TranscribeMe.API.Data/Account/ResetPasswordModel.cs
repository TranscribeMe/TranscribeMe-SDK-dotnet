using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data.Account
{
    public class ResetPasswordModel
    {
        [Required]
        public string Email { get; set; }
    }
}