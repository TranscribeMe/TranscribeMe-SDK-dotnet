namespace TranscribeMe.API.Data.Orders
{
    public class OrderSettingsModelBase
    {
        public string Language { get; set; }

        public string Accent { get; set; }

        public int? Type { get; set; }

        public int? Domain { get; set; }

        public int? Output { get; set; }

        public int? Turnaround { get; set; }

        public int? Speakers { get; set; }

        public bool? IsNoisyAudio { get; set; }

        public bool? IsHeavyAccent { get; set; }
    }
}