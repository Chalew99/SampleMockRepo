using Microsoft.Azure.WebJobs;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
 
namespace PushoverBindingExtensions
{
    internal class PushoverNotificationAsyncCollector : IAsyncCollector<PushoverNotification>
    {
        private static readonly HttpClient _httpClient = new HttpClient();
 
        private PushoverAttribute _pushoverAttribute;
 
        public PushoverNotificationAsyncCollector(PushoverAttribute attribute)
        {
            _pushoverAttribute = attribute;
        }
 
        public async Task AddAsync(PushoverNotification notification, CancellationToken cancellationToken = default(CancellationToken))
        {
            await SendNotification(notification);
        }
 
        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }
 
        private async Task SendNotification(PushoverNotification notification)
        {
            var parameters = new Dictionary<string, string>
                {
                    { "token", _pushoverAttribute.AppToken },
                    { "user", _pushoverAttribute.UserKey },
                    { "title", notification.Title },
                    { "message", notification.Message }
                };
 
            var response = await _httpClient.PostAsync("https://api.pushover.net/1/messages.json", new FormUrlEncodedContent(parameters));
            response.EnsureSuccessStatusCode();
        }
    }
}