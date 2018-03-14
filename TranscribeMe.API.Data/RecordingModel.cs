using System;

namespace TranscribeMe.API.Data
{
    public class RecordingModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string MediaId { get; set; }

        public decimal Duration { get; set; }

        public string RecordingFolderId { get; set; }

        public string Description { get; set; }

        public string LanguageCode { get; set; }

        public string LanguageAccent { get; set; }

        public string TranscriptionType { get; set; }

        public string NumberOfSpeakers { get; set; }

        public string TranscriptionTurnaroundHours { get; set; }

        public string TranscriptionOutputFormat { get; set; }

        public string RecordingDomain { get; set; }

        public bool IsLowQualityAudio { get; set; }

        public bool IsHeavyAccent { get; set; }

        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }

        public int Status { get; set; }

        public int StorageType { get; set; }
    }
}