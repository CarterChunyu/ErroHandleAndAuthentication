using ErrorHandlerandAuthetication.Helper;
using ErrorHandlerandAuthetication.ProjModels;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlerandAuthetication.ViewComponents
{
    public class LayoutHeader : ViewComponent
    {        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserInfo userInfo = HttpContext.GetObjectFromSession<UserInfo>("userInfo");
            var result = userInfo.AllFunctionNames.Split(',').Select(x =>
            {
                var functions = x.Split('-');
                if (functions[0].Contains("Api"))
                    return null;
                return new FuncInfo
                {
                    ParentCode = functions[0],
                    FuncCode = functions[1],
                    Url = $"/{functions[0]}/{functions[1]}"
                };
            }).Where(x => x!= null).GroupBy(x => x.ParentCode).Select(x => new HeaderInfo{ ParentCode = x.Key, FuncInfos = x.AsEnumerable()}).ToList();

            ViewBag.UserName = userInfo.UserName;

            return View(result);
        }
    }
}
