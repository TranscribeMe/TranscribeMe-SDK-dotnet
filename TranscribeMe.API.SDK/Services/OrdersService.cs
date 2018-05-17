using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using TranscribeMe.API.Data;
using TranscribeMe.API.Data.Billing;
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

        public async Task<CreateOrderModel> Create(IList<string> recordings)
        {
            if (recordings == null)
            {
                throw new ArgumentNullException(nameof(recordings));
            }

            var model = new CreateOrderModel { Recordings = recordings.ToList() };

            return await Create(model);
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

        public async Task<OrderDetailsModel> Get(string orderId)
        {
            var url = $"{_serviceUrl}/{orderId}";

            var response = await Client.GetAsync(url).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<OrderDetailsModel>();
        }

        public async Task<OrderDetailsModel> SetPromoCode(string orderId, string promoCode)
        {
            var url = $"{_serviceUrl}/{orderId}/promocode";
            var model = new PromoCodeModel { Code = promoCode };

            var response = await Client.PostAsJsonAsync(url, model).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<OrderDetailsModel>();
        }

        public async Task<OrderDetailsModel> EditRecordings(string orderId,
                                                            IList<OrderedRecordingModel> recordings)
        {
            var url = $"{_serviceUrl}/{orderId}/recordings/edit";

            var response = await Client.PostAsJsonAsync(url, recordings).ConfigureAwait(false);
            return await response.Content.ReadAsAsync<OrderDetailsModel>();
        }

        public async Task Place(string orderId)
        {
            var url = $"{_serviceUrl}/{orderId}/place";

            var model = new List<TransactionModel> { new TransactionModel { BillingType = 1 } };

            await Client.PostAsJsonAsync(url, model).ConfigureAwait(false);
        }
    }
}