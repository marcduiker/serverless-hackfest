using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.WebJobs.Host;

namespace HackfestApp
{
    public static class BlobInfo
    {
        [FunctionName("BlobInfo")]
        public static void Run(
            [EventGridTrigger] EventGridEvent eventGridEvent,
            [DocumentDB("data", "xpiritserverlessdata", ConnectionStringSetting = "CosmosDBConnection")] out dynamic document,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");


            log.Info($"blob subject: {eventGridEvent.Subject}.");

            document = new { EventSubject = eventGridEvent.Subject, EventId = eventGridEvent.Id };
        }
    }
}
