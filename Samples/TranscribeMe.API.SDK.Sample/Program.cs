using System;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Sample.Examples;

namespace TranscribeMe.API.SDK.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            Console.WriteLine("Initializing services...");

            await OrderWorkflow.InitializeServices();

            const string FileName = "";
            const string PromoCode = "";

            await CreateOrderSample(FileName, PromoCode);

            //const string RecordingId = "";
            //const string Format = "pdf";
            //const string OutputFile = "output.pdf";

            //await GetOrderResultSample(RecordingId, Format, OutputFile);
        }

        private static async Task CreateOrderSample(string fileName, string promoCode)
        {
            Console.WriteLine("Uploading file...");

            var recordingId = await OrderWorkflow.UploadFile(fileName);

            Console.WriteLine($"File uploaded: Recording Id: {recordingId}");
            Console.WriteLine("Creaating order...");

            var orderId = await OrderWorkflow.CreateOrder(recordingId);

            Console.WriteLine($"Order created. Order Id: {orderId}");
            Console.WriteLine("Setting promocode...");

            await OrderWorkflow.SetPromoCode(orderId, promoCode);

            Console.WriteLine("Updating order settings!");

            await OrderWorkflow.UpdateSettings(orderId);

            Console.WriteLine("Placing order...");
            await OrderWorkflow.PlaceOrder(orderId);

            Console.WriteLine("Order creation complete!");
        }

        private static async Task GetOrderResultSample(string recordingId, string format, string outputFile)
        {
            Console.WriteLine("Checking file status...");
            var status = await OrderWorkflow.CheckOrderStatus(recordingId);
            if (status == 3)
            {
                Console.WriteLine("Downloading result...");
                await OrderWorkflow.GetResult(recordingId, format, outputFile);
            }
            else
            {
                Console.WriteLine("File not ready yet!");
            }
        }
    }
}