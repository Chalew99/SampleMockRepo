using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AddStartup
{
    public class SayHello
    {
        private readonly IGreetingsService _greetingsService;

        public SayHello(IGreetingsService greetingsService)
        {
            this._greetingsService = greetingsService;
        }

        [FunctionName("SayHello")]
        public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "{name}")] HttpRequest req,
        ILogger log)
        {
            string name = req.Query["name"];

            return !string.IsNullOrWhiteSpace(name)
                ? (ActionResult)new OkObjectResult(_greetingsService.SayHi(name))
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }

    public interface IGreetingsService
    {
        string SayHi(string name);
    }

    public class GreetingsService : IGreetingsService
    {
        public string SayHi(string name)
        {
            return $"Hi, {name}! Pleased to meet you!";
        }
    }

}