using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace PushoverBindingExtensions
{
    [Extension("PushoverExtensions")]
    public class PushoverExtensions : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<PushoverAttribute>();

            rule.BindToCollector<PushoverNotification>(BuildCollector);
        }

        private IAsyncCollector<PushoverNotification> BuildCollector(PushoverAttribute attribute)
        {
            return new PushoverNotificationAsyncCollector(attribute);
        }
    }
}