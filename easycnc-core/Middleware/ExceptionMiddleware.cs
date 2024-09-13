using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json;

namespace easycnc_core.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception e)
            {
                var result = new
                {
                    code = 500,
                    msg = e.Message
                };
                httpContext.Response.StatusCode = 500;
               
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(result));
                await httpContext.Response.CompleteAsync();
            }
        }
    }

    public static class ExceptionMiddleExtensions
    {
        public static IApplicationBuilder UseException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
