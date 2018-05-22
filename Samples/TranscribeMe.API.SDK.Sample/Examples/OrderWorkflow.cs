using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using TranscribeMe.API.SDK.Auth;
using TranscribeMe.API.SDK.Services;
using TranscribeMe.API.SDK.Services.Interfaces;

namespace TranscribeMe.API.SDK.Sample.Examples
{
    public class OrderWorkflow
    {
        private static IUploadService _uploadService;
        private static IRecordingService _recordingService;
        private static IOrdersService _ordersService;

        /// <summary>
        /// Initializes all needed services.
        /// </summary>
        public static async Task InitializeServices()
        {
            // Load credentinals from config file
            var userCredentials = await TmApiWebAuthorizationBroker.AuthorizeAsync();
            var initializer = new BaseService.Initializer(userCredentials);

            _uploadService = new UploadService(initializer);
            _recordingService = new RecordingsService(initializer);
            _ordersService = new OrdersService(initializer);
        }

        /// <summary>
        /// Uploads the file.
        /// </summary>
        public static async Task<string> UploadFile(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            var recordingId = await _uploadService.Upload(path).ConfigureAwait(false);

            return recordingId;
        }

        /// <summary>
        /// Creates order.
        /// <param name="recordingId">Recording to order.</param>
        /// </summary>
        public static async Task<string> CreateOrder(string recordingId)
        {
            var order = await _ordersService.Create(new List<string> { recordingId });

            if (order == null)
            {
                Console.WriteLine("Order creating error!");
                return null;
            }

            return order.Id;
        }

        /// <summary>
        /// Sets promocode to order.
        /// <param name="orderId">Order Id to set promocode to.</param>
        /// <param name="promoCode">Promo code to set.</param>
        /// </summary>
        public static async Task SetPromoCode(string orderId, string promoCode)
        {
            await _ordersService.SetPromoCode(orderId, promoCode);
        }

        /// <summary>Updates order settings.</summary>
        /// <param name="orderId">Order Id to update settings.</param>
        /// <remarks>
        /// Current example updates all the recordings with the same values,
        /// but all the recording settings can be set individually.
        /// </remarks>
        public static async Task UpdateSettings(string orderId)
        {
            // Get order to have actual recording settings.
            var order = await _ordersService.Get(orderId);
            if (order == null)
            {
                Console.WriteLine("Can't find order for Id!");
                return;
            }

            // Change recording settings.
            foreach (var recording in order.Recordings)
            {
                recording.Settings.Speakers = 3;
            }

            await _ordersService.EditRecordings(orderId, order.Recordings);
        }

        /// <summary>Places the order.</summary>
        /// <param name="orderId">Order Id to place.</param>
        public static async Task PlaceOrder(string orderId)
        {
            await _ordersService.Place(orderId);
        }

        /// <summary>Checks the order status.</summary>
        /// <param name="recordingId">The recording identifier.</param>
        /// <returns>Order status.</returns>
        public static async Task<int> CheckOrderStatus(string recordingId)
        {
            return await _recordingService.GetStatus(recordingId);
        }

        /// <summary>Gets the result.</summary>
        /// <param name="recordingId">The recording identifier.</param>
        /// <param name="format">The format.</param>
        /// <param name="outputFile">The output file.</param>
        public static async Task GetResult(string recordingId, string format, string outputFile)
        {
            await _recordingService.GetResult(recordingId, format, outputFile);
        }
    }
}