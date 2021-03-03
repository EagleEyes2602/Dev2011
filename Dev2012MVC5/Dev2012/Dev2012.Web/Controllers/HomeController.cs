using Dev2012.Web.Models;
using Dev2012.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dev2012.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Request dữ liệu
            // Xử lý dữ liệu
            // Request/response view/data?
            //return View("Contact");

            // Những cách truyền dữ liệu từ action --> view
            // 1 số thành phần có thể giao tiếp dữ liệu giữa các action


            // ViewBag
            // Cách set giá trị vào ViewBag
            ViewBag.Text = "DevmasterAcademy";

            //string a = ViewBag.Name?.ToString();
            //string b = ViewBag.Name.ToString();

            // Cách get giá trị từ ViewBag
            string title = ViewBag.Text as string;

            // ViewData
            AccountModel account = new AccountModel()
            {
                Id = 1,
                UserName = "VIET-QQ",
                Email = "qquocviet2602@gmail.com"
            };
            ViewData["ModelViewData"] = account;

            // TempData
            TempData["ListAccount"] = new List<AccountModel>()
            {
                account,
                new AccountModel()
                {
                    Id = 2,
                    UserName = "TUAN-NA",
                    Email = "anhtuan@gmail.com"
                }
            };

            var lstAccount = new List<AccountModel>()
            {
                account,
                new AccountModel()
                {
                    Id = 2,
                    UserName = "TUAN-NA",
                    Email = "anhtuan@gmail.com"
                }
            };
            lstAccount.Add(
                new AccountModel()
                {
                    Id = 3,
                    UserName = "THIEN-TC",
                    Email = "trancaothien@gmail.com"
                }
            );

            // Model
            // object AccountModel
            // List<InformationModel>

            //return RedirectToAction("About");
            return View(lstAccount);
        }

        public ActionResult About()
        {
            // ViewModel
            // object AccountModel
            // List<InformationModel>
            ViewBag.Message = "Your application description page.";
            AboutViewModel model = new AboutViewModel();
            model.Account = new AccountModel()
            {
                Id = 1,
                UserName = "THAO-NT",
                Email = "nguyenthithao@gmail.com"
            };

            model.AccountInformation = new List<InformationModel>()
            {
                new InformationModel()
                {
                    Id = 1,
                    AccountId = 1,
                    Title = "Quê quán",
                    Detail = "Nam Định"
                },
                new InformationModel()
                {
                    Id = 2,
                    AccountId = 1,
                    Title = "Địa chỉ",
                    Detail = "Văn Miếu, Đống Đa, Hà Nội"
                }
            };

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public int ScalarNumber()
        {
            return 1;
        }

        public string ScalarString()
        {
            return "Devmaster";
        }

        public JsonResult JsonAct()
        {
            return Json(new { Id = 1, Name = "Nguyễn Anh Tuấn", Address = "Trung Kính" }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult PartialAct()
        {
            List<int> a = new List<int>();
            a.FirstOrDefault();
            return PartialView();
        }

        // CamelCase userName
        // Cap CamelCase ~ PascalCase UserName
        // SnakeCase user_name
        // AllCapSnakeCase USER_NAME
        // KebabCase user-name url
        [HttpPost]
        public ActionResult AccountAdd(int id, string userName, string email)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AccountAddModel(AccountModel data)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AccountAddRange(List<AccountModel> data)
        {
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult AccountAddAjax(int id, string userName, string email)
        {
            return Json(new { responseCode = "00", responseMessage = "Thành công" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AccountAddModelAjax(AccountModel data)
        {
            return Json(new { responseCode = "00", responseMessage = "Thành công" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AccountAddRangeAjax(List<AccountModel> data)
        {
            return Json(new { responseCode = "00", responseMessage = "Thành công" }, JsonRequestBehavior.AllowGet);
        }
    }
}