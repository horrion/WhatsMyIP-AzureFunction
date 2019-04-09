using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace RH.WhatsMyIP
{
    public static class WhatsMyIP_HttpTriggerCSharp
    {
        [FunctionName("WhatsMyIP_HttpTriggerCSharp")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //Get the Remote IP Address from HttpContext and cast it to a string
            var ipAddress = req.HttpContext.Connection.RemoteIpAddress;
            string ipAddressString = ipAddress.ToString();

            //Return the IP Address here
            return ipAddress != null
                ? (ActionResult)new OkObjectResult($"Your IP is {ipAddressString}")
                : new BadRequestObjectResult("No Remote IP found");
        }
    }
}
