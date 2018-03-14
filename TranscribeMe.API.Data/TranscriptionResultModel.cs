using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data
{
    public class TranscriptionWorkResultModel 
    {
        [Required]
        public string Result { get; set; }

        public decimal EarnedAmount { get; set; }

        public string AudioFeedbackCode { get; set; }

        public List<object> AdditionalData { get; set; }
    }
}