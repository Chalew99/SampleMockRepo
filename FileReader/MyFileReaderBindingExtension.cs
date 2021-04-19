using System;
using Microsoft.Azure.WebJobs;

namespace FileReader
{
    public static class MyFileReaderBindingExtension
    {
        public static IWebJobsBuilder AddMyFileReaderBinding(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<MyFileReaderBinding>();
            return builder;
        }
    }
}
