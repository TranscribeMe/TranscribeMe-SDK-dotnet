using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data.Account
{
    public class NewCustomerAccountModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Source { get; set; }
    }
}