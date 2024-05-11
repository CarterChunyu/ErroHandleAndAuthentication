using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Newtonsoft.Json;

namespace ErrorHandlerandAuthetication.Access
{
    public class MenuAccessMiddleware : IAuthorizationMiddlewareResultHandler
    {
        public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            if (authorizeResult.Succeeded)
            {
                await next.Invoke(context);
            }
            else
            {
                if(context.Request.Path.Value.Split('/').Any(x => x.ToLower() == "api"))
                {
                    context.Response.StatusCode = 403;
                    string json = JsonConvert.SerializeObject(new {result = "fail", message = "Login timeout" });
                    await context.Response.WriteAsync(json);
                }
                else
                {
                    context.Response.Redirect("/Login/Index?authMessage=Login_timeout");
                }

            }
        }
    }
}
