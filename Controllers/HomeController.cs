using AppBank.Models;
using AppBank.Models.Data;
using AppBank.Models.Entities;
using AppBank.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppBank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserData iUserData;

        public HomeController(ILogger<HomeController> logger, IUserData iUserData)
        {
            _logger = logger;
            this.iUserData = iUserData;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginUserVM loginUserVM)
        {
            UserAccount userData = iUserData.GetByAccount(loginUserVM.usuario);
            if (userData != null)
            {
                HttpContext.Session.SetInt32("UserId", userData.UserID);
            }

            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
