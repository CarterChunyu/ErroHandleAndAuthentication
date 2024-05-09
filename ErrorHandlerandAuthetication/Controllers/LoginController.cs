using Dapper;
using ErrorHandlerandAuthetication.DBContexts;
using ErrorHandlerandAuthetication.Helper;
using ErrorHandlerandAuthetication.Models;
using ErrorHandlerandAuthetication.ProjModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace ErrorHandlerandAuthetication.Controllers
{
    public class LoginController : Controller
    {
        private readonly ProjectContext _context;

        public LoginController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? ErrorMsg)
        {
            ViewBag.ErrorMsg = ErrorMsg;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUser loginUser) 
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Account == loginUser.Username && x.Password == loginUser.Password);
            if (user == null)
                return RedirectToAction("Index", "Login", new { ErrorMsg = "this person unfound" });

            UserInfo? userInfo = null;
            using(DbConnection conn = _context.Database.GetDbConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserID", user.UserId);
                userInfo = await conn.QueryFirstOrDefaultAsync<UserInfo>("TestDb1.dbo.UserInfo_SP", parameters, commandType: CommandType.StoredProcedure);
            }
            HttpContext.SetObjectTOSession<UserInfo>("userInfo", userInfo);

            return View();
        }
    }
}
