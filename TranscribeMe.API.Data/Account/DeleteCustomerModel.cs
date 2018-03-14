using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data.Account
{
    public class DeleteCustomerModel
    {
        [Required]
        public string Password { get; set; }
    }
}