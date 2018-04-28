# Sample of .NET Synchronous HTTP Handler

You can test it by sending **POST** request to `localhost:[port]//CallbackHandler/[any_path]` with request body in **JSON** format 

`Json request` sample:
```json
{ID:"123456-78990"}
```

## Implementation details
To catch callback you can use [Sample from MSDN](https://msdn.microsoft.com/en-us/library/ms228090.aspx)

Just replace body of `ProcessRequest` method and setup `Web.config`

### `IHttpHandler.ProcessRequest` implementation sample:
```c#
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
```

### `Web.config` sample:
```xml
<configuration>
    ...
    <system.webServer>
        <handlers>
            <add name="SampleHandler"
                 verb="POST" 
                 path="CallbackHandler/*" 
                 type="TranscribeMe.CallbackHandler.SampleHandler"/>
            </handlers>
    </system.webServer>
    ...
</configuration>
```