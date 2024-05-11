using AutoMapper;
using Dapper;
using ErrorHandlerandAuthetication.DBContexts;
using ErrorHandlerandAuthetication.Helper;
using ErrorHandlerandAuthetication.Models;
using ErrorHandlerandAuthetication.ProjModels;
using ErrorHandlerandAuthetication.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace ErrorHandlerandAuthetication.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ProjectContext _context;

        public LoginController(IMapper mapper,ProjectContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IActionResult Index(string? authMessage= "")
        {
            ViewBag.AuthMessage = authMessage;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUser loginUser) 
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Account == loginUser.Username && x.Password == loginUser.Password);
            if (user == null)
                return RedirectToAction("Index", "Login", new { ErrorMsg = "this person unfound" });
            UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);


            UserInfo? userInfo = null;
            using(DbConnection conn = _context.Database.GetDbConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserID", userViewModel.UserId);
                userInfo = await conn.QueryFirstOrDefaultAsync<UserInfo>("UserInfo_SP", parameters, commandType: CommandType.StoredProcedure);
            }
            HttpContext.Session.Clear();
            HttpContext.SetObjectTOSession<UserInfo>("userInfo", userInfo);

            return RedirectToAction("HomePage","Login");
        }

        public IActionResult HomePage()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
