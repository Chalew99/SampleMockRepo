using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PushoverBindingExtensions;

namespace CustomOPBSendPushoverNotification
{
    public static class CustomOPBSendPushoverNotification
    {
        [FunctionName("CustomOPBSendPushoverNotification")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
        [Pushover("%appkey%", "%userkey%")] IAsyncCollector<PushoverNotification> notifications,
        ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // validation omitted for demo purposes
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            await notifications.AddAsync(new PushoverNotification { Title = data.Title, Message = data.Message });

            return new OkResult();
        }
    }
}
