namespace TranscribeMe.API.Data
{
    public class TranscriptionTaskModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Result { get; set; }

        public string AudioName { get; set; }

        public string Extension { get; set; }

        public string FileName { get; set; }

        public double Duration { get; set; }

        public StyleGuidesGroupModel StyleGuidesGroup { get; set; }

        public string OrderedItemId { get; set; }

        public string ParentId { get; set; }

        public int Order { get; set; }

        public string LanguageCode { get; set; }

        public string AccentCode { get; set; }

        public int WorkflowId { get; set; }

        public int StorageType { get; set; } 
    }
}