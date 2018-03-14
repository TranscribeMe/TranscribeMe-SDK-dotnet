namespace TranscribeMe.API.Data.Subscriptions
{
    public class SubscriptionOrderListItemModel
    {
        public string Id { get; set; }

        public string TypeName { get; set; }

        public decimal TotalPaid { get; set; }

        public long StartDateTime { get; set; }

        public long ExpireDateTime { get; set; }

        public string Currency { get; set; }

        public int Period { get; set; }

        public double Duration { get; set; }

        public double TransferredDuration { get; set; }
    }
}