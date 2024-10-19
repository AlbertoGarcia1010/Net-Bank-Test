using Microsoft.AspNetCore.Mvc;

namespace AppBank.Controllers
{
    public class CashController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
