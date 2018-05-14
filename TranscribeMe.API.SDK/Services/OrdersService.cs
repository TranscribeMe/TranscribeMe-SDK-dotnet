using System.Net.Http;
using System.Threading.Tasks;

using TranscribeMe.API.Data.Orders;
using TranscribeMe.API.SDK.Services.Interfaces;

namespace TranscribeMe.API.SDK.Services
{
    public class OrdersService : BaseService, IOrdersService
    {
        private readonly string _serviceUrl = "orders";

        public OrdersService(Initializer initializer)
            : base(initializer)
        {
        }

        public async Task<CreateOrderModel> Create(CreateOrderModel instance)
        {
            var response = await Client.PostAsJsonAsync(_serviceUrl, instance).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<CreateOrderModel>();
        }

        public async Task Delete(string orderId)
        {
            var url = $"{_serviceUrl}/{orderId}";

            await Client.DeleteAsync(url).ConfigureAwait(false);
        }

        public async Task<OrderDetailsModel> SetPromoCode(string orderId, OrderPromoCodeModel promoCode)
        {
            var url = $"{_serviceUrl}/{orderId}/promocode";

            var response = await Client.PostAsJsonAsync(url, promoCode).ConfigureAwait(false);

            return await response.Content.ReadAsAsync<OrderDetailsModel>();
        }
    }
}