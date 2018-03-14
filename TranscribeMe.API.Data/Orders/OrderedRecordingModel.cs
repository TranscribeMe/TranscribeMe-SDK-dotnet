using System.Collections.Generic;

namespace TranscribeMe.API.Data.Orders
{
    public class OrderedRecordingModel
    {
        public OrderedRecordingModel()
        {
            Settings = new OrderItemSettingsModel();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Total { get; set; }

        public decimal Adjustment { get; set; }

        public decimal Refund { get; set; }

        public double Duration { get; set; }

        public OrderItemSettingsModel Settings { get; set; }

        public IList<NamedEntityModel> Docs { get; set; }

        public decimal Rate { get; set; }

        public string Source { get; set; }
    }
}