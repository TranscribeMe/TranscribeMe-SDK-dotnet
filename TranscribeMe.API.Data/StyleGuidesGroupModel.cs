using System.Collections.Generic;

namespace TranscribeMe.API.Data
{
    public class StyleGuidesGroupModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LanguageCode { get; set; }

        public string LanguageAccentCode { get; set; }

        public IList<StyleGuideRuleModel> Rules { get; set; }
    }
}