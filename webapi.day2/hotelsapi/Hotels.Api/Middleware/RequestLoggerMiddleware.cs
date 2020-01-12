namespace Hotels.Api.Middleware
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Services;

    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate next;

        // #3 custom middleware
        public RequestLoggerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ISimpleLogger simpleLogger)
        {
            simpleLogger.LogInfo($"Handling request: {context.Request.Method} {context.Request.Path}");

            await this.next.Invoke(context);

            simpleLogger.LogInfo("Finished handling request.");
        }
    }
}
