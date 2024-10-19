using Microsoft.AspNetCore.Mvc;
using AppBank.App.Utils;
using AppBank.Models.Data;
using AppBank.Models.Entities;

namespace AppBank.Controllers
{
    public class RetirosController : PrivateBaseController
    {
        private readonly IUserData iUserData;
        public RetirosController(ILogger<RetirosController> logger,
            IUserData iUserData) : base(logger)
        {
            this.iUserData = iUserData;
        }
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            ViewBag.Total = iUserData.Get((int)userId).Quantity;
            return View();
        }

        [HttpPost]
        public IActionResult UpdateSaldo(int decrementQuantity)
        {
            Console.WriteLine("UpdateSaldo: " + decrementQuantity);
            var userId = HttpContext.Session.GetInt32("UserId");
            UserAccount userAccount = iUserData.Get((int)userId);
            userAccount.Quantity = userAccount.Quantity - decrementQuantity;

            Boolean isEdited = iUserData.Edit(userAccount);
            if (isEdited)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Total = userAccount.Quantity;
            return View();
        }
    }
}
