using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace HackfestApp
{
    public static class Start
    {
        [FunctionName("Start")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req,
            [DocumentDB("data", "xpiritserverlessdata", ConnectionStringSetting = "CosmosDBConnection")] out dynamic document,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

           // Get request body
            dynamic data = req.Content.ReadAsAsync<object>().Result;
            var name = data?.name;

            document = new { Name = name, id = Guid.NewGuid() };

            return name == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK);
        }
    }
}
