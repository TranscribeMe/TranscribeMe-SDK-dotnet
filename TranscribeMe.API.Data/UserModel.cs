using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data
{
    public class UserModel
    {
        public string Id { get; set; }

        [Required, EmailAddress]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password), StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Source { get; set; }

        public string Language { get; set; }

        [Required, Url]
        public string UserActivationUrl { get; set; }

        [Required]
        public string Role { get; set; }

    }
}