using System;
using System.ComponentModel.DataAnnotations;

namespace TranscribeMe.API.Data
{
    public class UploadLinkRequestModel
    {
        [Required]
        public string FileName { get; set; }

        public TimeSpan? Period { get; set; }
    }
}