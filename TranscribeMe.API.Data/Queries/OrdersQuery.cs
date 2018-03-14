using TranscribeMe.API.Data.Orders;

namespace TranscribeMe.API.Data.Queries
{
    public class OrdersQuery : PageableFilterQueryBase<ObjectsList<OrderListItemModel>>
    {
        public int? Status { get; set; }

        public string User { get; set; }
    }
}