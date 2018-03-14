using System.Collections.Generic;

namespace TranscribeMe.API.Data.Orders
{
    public class OrderListItemModel
    {
        public string Id { get; set; }

        public double Duration { get; set; }

        public double FreeDuration { get; set; }

        public long Created { get; set; }

        public int Status { get; set; }

        public int Recordings { get; set; }

        public long Paid { get; set; }

        public decimal Total { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Discount { get; set; }

        public decimal Adjustment { get; set; }

        public decimal Refund { get; set; }

        public decimal GrandTotal => Total - Refund;

        public string Currency { get; set; }

        public IList<int> BillingType { get; set; }
    }
}