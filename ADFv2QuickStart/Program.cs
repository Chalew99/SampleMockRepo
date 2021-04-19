using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.Services.AppAuthentication;

namespace ADFv2QuickStart
{
    class Program
    {
        //static void Main(string[] args)
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            // Set variables
            string tenantID = "microsoft.onmicrosoft.com";
            string User = "Liquid-adf-dev";
            string applicationId = "<your application ID>";
            string authenticationKey = "<your authentication key for the application>";
            string subscriptionId = "b67993e8-0937-4812-af89-520a495da302";
            string resourceGroup = "vchmeha";
            string region = "West Central US";
            string dataFactoryName = "ADFv2HaHu";
            string storageAccount = "fromblob";
            string storageKey = "gREZ3TbADUcfWJ+ryfxOH7FKrlCKobMHrpS7Z2PPS/gQIsH02LHAGedlqYVpxm/PeWHDJsU/wkBmNz1Q20Rwyg==";
            // specify the container and input folder from which all files 
            // need to be copied to the output folder. 
            string inputBlobPath = "adftutorial/input";
            //specify the contains and output folder where the files are copied
            string outputBlobPath = "adftutorial/output";

            // name of the Azure Storage linked service, blob dataset, and the pipeline
            string storageLinkedServiceName = "AzureStorageLinkedService";
            string blobDatasetName = "BlobDataset";
            string pipelineName = "Adfv2QuickStartPipeline";

            // Authenticate and create a data factory management client
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var token = await azureServiceTokenProvider.GetAccessTokenAsync("https://management.azure.com/");
            var cred = new TokenCredentials(token);
            var client = new DataFactoryManagementClient(cred) { SubscriptionId = subscriptionId };

            // Create a data factory
            Console.WriteLine("Creating data factory " + dataFactoryName + "...");
            Factory dataFactory = new Factory
            {
                Location = region,
                Identity = new FactoryIdentity()
            };
            client.Factories.CreateOrUpdate(resourceGroup, dataFactoryName, dataFactory);
            Console.WriteLine(
                SafeJsonConvert.SerializeObject(dataFactory, client.SerializationSettings));

            while (client.Factories.Get(resourceGroup, dataFactoryName).ProvisioningState ==
                   "PendingCreation")
            {
                System.Threading.Thread.Sleep(1000);
            }


            // Create an Azure Storage linked service
            Console.WriteLine("Creating linked service " + storageLinkedServiceName + "...");

            LinkedServiceResource storageLinkedService = new LinkedServiceResource(
                new AzureStorageLinkedService
                {
                    ConnectionString = new SecureString(
                        "DefaultEndpointsProtocol=https;AccountName=" + storageAccount +
                        ";AccountKey=" + storageKey)
                }
            );
            client.LinkedServices.CreateOrUpdate(
                resourceGroup, dataFactoryName, storageLinkedServiceName, storageLinkedService);
            Console.WriteLine(SafeJsonConvert.SerializeObject(
                storageLinkedService, client.SerializationSettings));

            // Create an Azure Blob dataset
            Console.WriteLine("Creating dataset " + blobDatasetName + "...");
            DatasetResource blobDataset = new DatasetResource(
                new AzureBlobDataset
                {
                    LinkedServiceName = new LinkedServiceReference
                    {
                        ReferenceName = storageLinkedServiceName
                    },
                    FolderPath = new Expression { Value = "@{dataset().path}" },
                    Parameters = new Dictionary<string, ParameterSpecification>
                    {
            { "path", new ParameterSpecification { Type = ParameterType.String } }
                    }
                }
            );
            client.Datasets.CreateOrUpdate(
                resourceGroup, dataFactoryName, blobDatasetName, blobDataset);
            Console.WriteLine(
                SafeJsonConvert.SerializeObject(blobDataset, client.SerializationSettings));

            // Create a pipeline with a copy activity
            Console.WriteLine("Creating pipeline " + pipelineName + "...");
            PipelineResource pipeline = new PipelineResource
            {
                Parameters = new Dictionary<string, ParameterSpecification>
    {
        { "inputPath", new ParameterSpecification { Type = ParameterType.String } },
        { "outputPath", new ParameterSpecification { Type = ParameterType.String } }
    },
                Activities = new List<Activity>
    {
        new CopyActivity
        {
            Name = "CopyFromBlobToBlob",
            Inputs = new List<DatasetReference>
            {
                new DatasetReference()
                {
                    ReferenceName = blobDatasetName,
                    Parameters = new Dictionary<string, object>
                    {
                        { "path", "@pipeline().parameters.inputPath" }
                    }
                }
            },
            Outputs = new List<DatasetReference>
            {
                new DatasetReference
                {
                    ReferenceName = blobDatasetName,
                    Parameters = new Dictionary<string, object>
                    {
                        { "path", "@pipeline().parameters.outputPath" }
                    }
                }
            },
            Source = new BlobSource { },
            Sink = new BlobSink { }
        }
    }
            };
            client.Pipelines.CreateOrUpdate(resourceGroup, dataFactoryName, pipelineName, pipeline);
            Console.WriteLine(SafeJsonConvert.SerializeObject(pipeline, client.SerializationSettings));

            // Create a pipeline run
            Console.WriteLine("Creating pipeline run...");
            Dictionary<string, object> parameters = new Dictionary<string, object>
{
    { "inputPath", inputBlobPath },
    { "outputPath", outputBlobPath }
};
            CreateRunResponse runResponse = client.Pipelines.CreateRunWithHttpMessagesAsync(
                resourceGroup, dataFactoryName, pipelineName, parameters: parameters
            ).Result.Body;
            Console.WriteLine("Pipeline run ID: " + runResponse.RunId);

            // Monitor the pipeline run
            Console.WriteLine("Checking pipeline run status...");
            PipelineRun pipelineRun;
            while (true)
            {
                pipelineRun = client.PipelineRuns.Get(
                    resourceGroup, dataFactoryName, runResponse.RunId);
                Console.WriteLine("Status: " + pipelineRun.Status);
                if (pipelineRun.Status == "InProgress" || pipelineRun.Status == "Queued")
                    System.Threading.Thread.Sleep(15000);
                else
                    break;
            }

            // Check the copy activity run details
            Console.WriteLine("Checking copy activity run details...");

            RunFilterParameters filterParams = new RunFilterParameters(
                DateTime.UtcNow.AddMinutes(-10), DateTime.UtcNow.AddMinutes(10));
            ActivityRunsQueryResponse queryResponse = client.ActivityRuns.QueryByPipelineRun(
                resourceGroup, dataFactoryName, runResponse.RunId, filterParams);
            if (pipelineRun.Status == "Succeeded")
                Console.WriteLine(queryResponse.Value.First().Output);
            else
                Console.WriteLine(queryResponse.Value.First().Error);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }
    }
}
