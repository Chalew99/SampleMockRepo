
using FileReader;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;


[assembly: WebJobsStartup(typeof(MyFileReaderBindingStartup))]
namespace FileReader
{
    public class MyFileReaderBindingStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddMyFileReaderBinding();
        }
    }
}