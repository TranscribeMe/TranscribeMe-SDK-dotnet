using Newtonsoft.Json;

namespace TranscribeMe.API.Data
{
    public class DictionaryItemModel
    {
        public DictionaryItemModel()
        {
        }

        public DictionaryItemModel(object id, string name)
        {
            Id = id;
            Name = name;
        }

        public DictionaryItemModel(object id, string name, string description) : this(id, name)
        {
            Description = description;
        }

        public DictionaryItemModel(object id, string name, bool? isDefault) : this(id, name)
        {
            IsDefault = isDefault;
        }

        public DictionaryItemModel(object id, string name, string description, bool? isDefault) 
            : this(id, name, description)
        {
            IsDefault = isDefault;
        }

        public object Id { get; set; }

        public string Name { get; set; } 

        public string Description { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsDefault { get; set; }
    }
}