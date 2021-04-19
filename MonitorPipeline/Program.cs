using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace MonitorPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Set variables
            string tenantID = "<your tenant ID>";
            string applicationId = "<your application ID>";
            string authenticationKey = "<your authentication key for the application>";
            string subscriptionId = "<your subscription ID where the data factory resides>";
            string resourceGroup = "<your resource group where the data factory resides>";
            string region = "<the location of your resource group>";
            string dataFactoryName =
                "<specify the name of data factory to create. It must be globally unique.>";
            string storageAccount = "<your storage account name to copy data>";
            string storageKey = "<your storage account key>";
            // specify the container and input folder from which all files 
            // need to be copied to the output folder. 
            string inputBlobPath =
                "<path to existing blob(s) to copy data from, e.g. containername/inputdir>";
            //specify the contains and output folder where the files are copied
            string outputBlobPath =
                "<the blob path to copy data to, e.g. containername/outputdir>";

            // name of the Azure Storage linked service, blob dataset, and the pipeline
            string storageLinkedServiceName = "AzureStorageLinkedService";
            string blobDatasetName = "BlobDataset";
            string pipelineName = "Adfv2QuickStartPipeline";
        }
    }
}
