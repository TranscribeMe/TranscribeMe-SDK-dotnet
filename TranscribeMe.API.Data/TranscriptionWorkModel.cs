using System;
using System.Collections.Generic;

namespace TranscribeMe.API.Data
{
    public class TranscriptionWorkModel
    {
        public string Id { get; set; }

        public TranscriptionTaskModel Task { get; set; }

        public List<object> AdditionalData { get; set; }

        public string WorkerId { get; set; }

        public string Status { get; set; }

        public string Speakers { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateSubmitted { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}