using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data
{
    public class UserPasswordModel
    {
        [Required, 
         Compare("RepeatPassword"), 
         DataType(DataType.Password), 
         StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public string RepeatPassword { get; set; }
    }
}