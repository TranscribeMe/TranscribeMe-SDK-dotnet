using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TranscribeMe.CallbackHandler
{
    /// <summary>
    /// Summary description for SampleHandler
    /// </summary>
    public class SampleHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var request = context.Request;
            if (request.ContentLength == 0)
            {
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                context.Response.StatusDescription = "Request body is empty";
                return;
            }
            var buffer = new byte[request.ContentLength];
            var bitesReaded = request.InputStream.Read(buffer, 0, request.ContentLength);
            var jsonString = System.Text.UTF8Encoding.UTF8.GetString(buffer);
            var json = Newtonsoft.Json.Linq.JObject.Parse(jsonString);
            var recordingId = json["ID"].ToString();
            context.Response.Write(recordingId);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}