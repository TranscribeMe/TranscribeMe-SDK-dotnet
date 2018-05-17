using System.Collections.Generic;
using System.Threading.Tasks;

using TranscribeMe.API.Data.Orders;
using TranscribeMe.API.SDK.Services.Interfaces.Crud;

namespace TranscribeMe.API.SDK.Services.Interfaces
{
    public interface IOrdersService : ICreateService<CreateOrderModel>, IDeleteService
    {
        Task<OrderDetailsModel> Get(string orderId);

        Task<OrderDetailsModel> SetPromoCode(string orderId, OrderPromoCodeModel promoCode);

        Task<OrderDetailsModel> EditRecordings(string orderId, IList<OrderedRecordingModel> recordings);

        Task Place(string orderId);
    }
}