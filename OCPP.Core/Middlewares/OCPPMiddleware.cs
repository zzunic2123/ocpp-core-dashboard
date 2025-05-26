using System.Net;
using System.Text;
using CPMS.OcppProxy.Services.Interfaces;

namespace CPMS.OcppProxy.Middlewares
{
    public partial class OCPPMiddleware
    {
       
        private readonly RequestDelegate _next;
        private readonly IOCPPMiddlewareService _ocppMiddlewareService;
        
        public OCPPMiddleware(RequestDelegate next, IOCPPMiddlewareService ocppMiddlewareService)
        {
            _next = next;
            _ocppMiddlewareService = ocppMiddlewareService;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/OCPP"))
                await _ocppMiddlewareService.HandleOCPPRequest(context);
            else if (context.Request.Path.StartsWithSegments("/api/health"))
                await _ocppMiddlewareService.HandleRootRequest(context);
            else if (context.Request.Path.StartsWithSegments("/api"))
            {
                context.Request.EnableBuffering(); // Enable buffering to read the body multiple times

                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
                {
                    var requestBody = await reader.ReadToEndAsync();
                    Console.WriteLine($"Request Body: {requestBody}");

                    // Reset the stream position for further middleware to process it
                    context.Request.Body.Position = 0;
                }

                await _next(context);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }

    public static class OCPPMiddlewareExtensions
    {
        public static IApplicationBuilder UseOCPPMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OCPPMiddleware>();
        }
    }
}
