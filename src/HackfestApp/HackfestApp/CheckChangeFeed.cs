using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace HackfestApp
{
    public static class CheckChangeFeed
    {
        [FunctionName("CheckChangeFeed")]
        public static void Run(
        [CosmosDBTrigger("data", "xpiritserverlessdata", ConnectionStringSetting = "CosmosDBConnection")]
        IReadOnlyList<Document> documents,
        TraceWriter log)
        {
            if (documents != null && documents.Count > 0)
            {
                foreach (var document in documents)
                {
                    log.Verbose($"Logging document: {document.Id}");    
                }
            }
        }
    }
}
