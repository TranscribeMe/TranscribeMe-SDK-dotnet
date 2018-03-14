using System.Collections.Generic;

namespace TranscribeMe.API.Data
{
    public class WaveformModel
    {
        public string Name { get; set; }

        public IEnumerable<sbyte> Array { get; set; }

        public short SampleRate { get; set; }

        public byte BitsPerSample { get; set; }
    }
}
