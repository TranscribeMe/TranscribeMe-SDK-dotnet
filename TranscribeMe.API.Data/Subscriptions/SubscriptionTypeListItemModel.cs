namespace TranscribeMe.API.Data.Subscriptions
{
    public class SubscriptionTypeListItemModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public decimal Price { get; set; }

        public int Period { get; set; }

        public double Duration { get; set; }

        public decimal OverLimitPricePerMinute { get; set; }

        public string Description { get; set; }
    }
}