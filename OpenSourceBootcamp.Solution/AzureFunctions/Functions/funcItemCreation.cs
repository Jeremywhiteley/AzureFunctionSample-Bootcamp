using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using AzureFunctions.Helpers;
using AzureFunctions.Domain;
using Newtonsoft.Json;

namespace AzureFunctions.Functions
{
    public static class funcItemCreation
    {
        [FunctionName("funcItemCreation")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Get request body
            var data = await req.Content.ReadAsStringAsync();
            var compra = JsonConvert.DeserializeObject<Compras>(data);

            using (AzureCosmosDBHelper helper = new AzureCosmosDBHelper())
            {
                helper.Save<Compras>(compra);
            }

            return req.CreateResponse(HttpStatusCode.OK, "A requisição foi realizada com sucesso.");
        }
    }
}
