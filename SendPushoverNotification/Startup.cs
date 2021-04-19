using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using PushoverBindingExtensions;

namespace CustomOPBSendPushoverNotification
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddExtension<PushoverExtensions>();
        }
    }
}
