using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;

using TranscribeMe.API.Data.Queries;
using TranscribeMe.API.SDK.Auth;
using TranscribeMe.API.SDK.Services;
using TranscribeMe.API.SDK.Services.Interfaces;

namespace TranscribeMe.API.SDK.Sample
{
    class Program
    {
        public static void Main(string[] args)
        {
            var secret = new ApplicationCredentials("", "");
            var credentials = TmApiWebAuthorizationBroker.AuthorizeAsync(secret, "", "", Config.Sandbox).Result;

            var recordingService = new RecordingsService(new BaseService.Initializer(credentials));
            var result = recordingService.Get(new RecordingsQuery { User = "" });

            result.Wait();

            Console.WriteLine(result.Result.Total);
        }

        public static async Task UploadAsyncTest(IUploadService service)
        {
            const string FileName = "";

            var model = await service.GetUploadUrl(FileName, true);

            var queryDictionary = HttpUtility.ParseQueryString(model.Url.Query);

            var recordingId = queryDictionary["recordingId"];
            var uploadId = queryDictionary["uploadId"];

            using (var fileStream = File.OpenRead(FileName))
            {
                int chunkSize = 5242880;
                var chunksCount = (int)Math.Ceiling(fileStream.Length / (double)chunkSize);
                for (var i = 0; i < chunksCount; i++)
                {
                    using (var inputStream = new MemoryStream())
                    {
                        var bufferSize = i < chunksCount - 1
                            ? chunkSize
                            : fileStream.Length - chunkSize * (chunksCount - 1);
                        var buffer = new byte[bufferSize];

                        fileStream.Read(buffer, 0, buffer.Length);

                        inputStream.Write(buffer, 0, buffer.Length);
                        inputStream.Seek(0, SeekOrigin.Begin);

                        var chunkUploadResult = await service.UploadChunk(uploadId, recordingId, i, inputStream);
                    }
                }
            }

            var commitResult = await service.CommitAsyncUpload(uploadId, recordingId);
        }
    }
}