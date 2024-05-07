using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace ErrorHandlerandAuthetication.Middlewares
{
    public class GlobalExceptionHandleMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandleMiddleware> _logger;

        public GlobalExceptionHandleMiddleware(ILogger<GlobalExceptionHandleMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(eventId: ex.HResult , exception: ex, message: ex.Message);
               
                Regex regex = new Regex(@"/api/", RegexOptions.IgnoreCase);
                if (!regex.IsMatch(context.Request.Path.Value))
                {
                    context.Response.Redirect("/Error/Error");
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    string json = JsonConvert.SerializeObject(new { message = ex.Message });
                    await context.Response.WriteAsJsonAsync(json);
                }
            }
        }
    }
}
