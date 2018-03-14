namespace TranscribeMe.API.Data.Recordings
{
    public class RecordingListItemModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Duration { get; set; }

        public long Created { get; set; }

        public int Status { get; set; }

        public int OutputFormatGroup { get; set; }

        public string MediaId { get; set; }

        public int StorageType { get; set; }

        public string Folder { get; set; }

        public int Rate { get; set; }

        public string Order { get; set; }

        public bool IsUpgradable { get; set; }

        public HierarchyItemModel Parent { get; set; }
    }
}