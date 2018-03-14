using System.Collections.Generic;

namespace TranscribeMe.API.Data.Orders
{
    public class CreateOrderModel
    {
        public CreateOrderModel()
        {
            Recordings = new List<string>();
        }

        public string Id { get; set; }

        public IList<string> Recordings { get; set; }
    }
}