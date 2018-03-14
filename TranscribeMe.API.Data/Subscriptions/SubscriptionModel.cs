namespace TranscribeMe.API.Data.Subscriptions
{
    public class SubscriptionModel
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public double Balance { get; set; }

        public long Expiration { get; set; }

        public double PricePerMinute { get; set; }

        public bool AllowPayment => PricePerMinute > 0;

        public bool IsAutoRenew { get; set; }

        public string LastOrderId { get; set; }
    }
}