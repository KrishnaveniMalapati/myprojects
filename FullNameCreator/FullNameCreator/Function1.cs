using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FullNameCreator
{
    public class Function
    {
        private readonly ILogger _logger;

        public Function(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function>();
        }

        [Function("Function1")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous,
            "get", "post",
            Route = "FullName")]
         HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(new
            {
               // string firstName = req.Query["first"],
               // string lastName = req.Query["last"],

                FirstName = "Krishnaveni",
                LastName = "kkkkkk",
                CurrentTime = DateTime.UtcNow
            });
                   
            return response;
        }
        [Function("GetFullName")]
        public async Task<HttpResponseData> GetFullName([HttpTrigger(AuthorizationLevel.Anonymous,
            "get", "post",
            Route = "GetFullName")]
         HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(new
            {
                // string firstName = req.Query["first"],
                // string lastName = req.Query["last"],

                FirstName = "Krishnaveni",
                LastName = "kkkkkk",
                CurrentTime = DateTime.UtcNow
            });

            return response;
        }


    }
}
