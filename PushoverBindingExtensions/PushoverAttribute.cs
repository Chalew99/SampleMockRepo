using Microsoft.Azure.WebJobs.Description;
using System;

namespace PushoverBindingExtensions
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class PushoverAttribute : Attribute
    {
        public PushoverAttribute(string appToken, string userKey)
        {
            AppToken = appToken;
            UserKey = userKey;
        }

        [AutoResolve]
        public string AppToken { get; set; }

        [AutoResolve]
        public string UserKey { get; set; }
    }
}