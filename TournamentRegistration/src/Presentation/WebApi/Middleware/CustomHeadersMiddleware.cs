using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApi.Middleware
{
    public class CustomHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add("X-Custom-Header", "My custom header value");
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
