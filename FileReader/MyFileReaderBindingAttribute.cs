using System;
using Microsoft.Azure.WebJobs.Description;

namespace FileReader
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class MyFileReaderBindingAttribute : Attribute
    {
        [AutoResolve]
        public string Location { get; set; }
    }
}
