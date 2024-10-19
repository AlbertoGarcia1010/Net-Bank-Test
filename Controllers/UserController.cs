using AppBank.App.Utils;
using AppBank.Models.Data;
using AppBank.Models.Entities;
using AppBank.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Text.Json;

namespace AppBank.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserData iUserData;

        public UserController(IUserData iUserData)
        {
            this.iUserData = iUserData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserID,UserNameComplete,Account,UserPassword,Quantity,StatusID,DateCreate")] UserAccountVM userAccountVM)
        {
            UserAccount userAccount = dataConvertion(userAccountVM);
            if (ModelState.IsValid)
            {
                iUserData.Insert(userAccount);

                return RedirectToAction("Index");
            }
            return View(userAccountVM);
        }


        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = iUserData.Get(id);
            if (userAccount == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }
            UserAccountVM userAccountVM = dataConvertionToVM(userAccount);
            return View(userAccountVM);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = iUserData.Get(id);

            if (userAccount == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            UserAccountVM userAccountVM = dataConvertionToVM(userAccount);
            return View(userAccountVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("UserID,UserNameComplete,Account,UserPassword,Quantity,StatusID,DateCreate,DateUpdate")] UserAccountVM userAccountVM)
        {
            int isUpdate = 1;
            UserAccount userAccount = dataConvertion(userAccountVM, isUpdate);
            if (ModelState.IsValid)
            {
                iUserData.Edit(userAccount);

                return RedirectToAction("Index");
            }
            return View(userAccountVM);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = iUserData.Get(id);
            if (userAccount == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            return View(userAccount);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            UserAccount userAccount = iUserData.Get(id);

            Boolean success = iUserData.Delete(userAccount);
            if (success)
            {
                return Json(new { result = "Ok", url = "", msg = "Cuenta Eliminada" });
            }
            else
            {
                return Json(new { result = "Error", url = "", msg = "Error al eliminar" });
            }
        }

        public IActionResult LoadAccounts()
        {
            int start = Convert.ToInt32(Request.Query["start"]);
            int length = Convert.ToInt32(Request.Query["length"]);
            string searchValue = Request.Query["search[value]"];
            string sortColumnName = Request.Query["columns[" + Request.Query["order[0][column]"] + "][name]"];
            string sortDirection = Request.Query["order[0][dir]"];

            ListDataModel list = iUserData.List();

            return Json(new { data = list.data, draw = Request.Query["draw"], recordsTotal = list.totalrows, recordsFiltered = list.rowsfiltered });
        }

        private UserAccount dataConvertion(UserAccountVM userAccountVM, int isUpdate = 0)
        {
            UserAccount userAccount = new UserAccount();
            DateTime date = DateTime.Now;
            string dateFormatCustom = date.ToString("yyyy/MM/dd HH:mm:ss");

            userAccount.UserNameComplete = userAccountVM.UserNameComplete;
            userAccount.Account = userAccountVM.Account;
            userAccount.UserPassword = userAccountVM.UserPassword;
            userAccount.Quantity = userAccountVM.Quantity;
            userAccount.StatusID = 1;

            if (isUpdate > 0)
            {
                userAccount.UserID = userAccountVM.UserID;
                userAccount.DateUpdate = DateTime.Parse(dateFormatCustom);
                userAccount.DateCreate = userAccountVM.DateCreate;
            }
            else
            {
                userAccount.DateCreate = DateTime.Parse(dateFormatCustom);
            }

            return userAccount;
        }

        private UserAccountVM dataConvertionToVM(UserAccount userAccount)
        {
            UserAccountVM userAccountVM = new UserAccountVM();
            DateTime date = DateTime.Now;
            string dateFormatCustom = date.ToString("yyyy/MM/dd HH:mm:ss");

            userAccountVM.UserID = userAccount.UserID;
            userAccountVM.Account = userAccount.Account;
            userAccountVM.UserNameComplete = userAccount.UserNameComplete;
            userAccountVM.UserPassword = userAccount.UserPassword;
            userAccountVM.Quantity = userAccount.Quantity;
            userAccountVM.StatusID = 1;
            userAccountVM.DateCreate = userAccount.DateCreate;

            return userAccountVM;
        }

    }
}
