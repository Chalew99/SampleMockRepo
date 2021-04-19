using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;

[assembly: WebJobsStartup(typeof(AddStartup.Startup))]
namespace AddStartup
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            //throw new System.NotImplementedException();

            builder.Services.TryAddScoped<IGreetingsService, GreetingsService>();
            // OR
           // builder.Services.TryAddScoped(typeof(IGreetingsService), typeof(GreetingsService));
        }
    }
}