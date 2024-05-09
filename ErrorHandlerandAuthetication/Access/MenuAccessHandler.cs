using ErrorHandlerandAuthetication.Helper;
using ErrorHandlerandAuthetication.ProjModels;
using Microsoft.AspNetCore.Authorization;

namespace ErrorHandlerandAuthetication.Access
{
    public class MenuAccessHandler : AuthorizationHandler<MenuAccess>
    {
        private readonly IHttpContextAccessor _accessor;

        public MenuAccessHandler(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MenuAccess requirement)
        {
            try
            {
                string[] pathArr = _accessor.HttpContext.Request.Path.Value.Split("/");
                string requestFcuntions = pathArr[1].ToLower() == "api" ? $"{pathArr[2]}-{pathArr[3]}" : $"{pathArr[1]}-{pathArr[2]}";

                UserInfo userInfo = _accessor.HttpContext.GetObjectFromSession<UserInfo>("userInfo");

                if (userInfo.AllFunctionNames.Split(",").Any( x=> x.ToLower() == requestFcuntions.ToLower()))
                    context.Succeed(requirement);
                else
                    context.Fail();
            }
            catch(Exception ex)
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
