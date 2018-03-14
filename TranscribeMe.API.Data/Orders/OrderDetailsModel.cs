using System.Collections.Generic;
using TranscribeMe.API.Data.Billing;
using TranscribeMe.API.Data.Subscriptions;

namespace TranscribeMe.API.Data.Orders
{
    public class OrderDetailsModel : OrderListItemModel
    {
        public OrderDetailsModel()
        {
            Recordings = new List<OrderedRecordingModel>();
        }

        public PromoCodeModel PromoCode { get; set; }

        public new IList<OrderedRecordingModel> Recordings { get; set; }

        public OrderSubscriptionModel Subscription { get; set; }

        public CreditCardModel CreditCard { get; set; }
    }
}