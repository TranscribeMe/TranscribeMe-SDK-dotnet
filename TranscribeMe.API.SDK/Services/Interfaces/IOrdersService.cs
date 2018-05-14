using TranscribeMe.API.Data.Orders;
using TranscribeMe.API.SDK.Services.Interfaces.Crud;

namespace TranscribeMe.API.SDK.Services.Interfaces
{
    public interface IOrdersService : ICreateService<CreateOrderModel>, IDeleteService
    {
    }
}