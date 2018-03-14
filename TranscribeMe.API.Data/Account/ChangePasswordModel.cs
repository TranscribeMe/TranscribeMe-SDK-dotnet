using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data.Account
{
    public class ChangePasswordModel
    {
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}