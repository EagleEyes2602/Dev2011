using Dev2012.Web.Helpers;
using Dev2012.Web.Models;
using Dev2012.Web.Models.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dev2012.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly QuanLyThuVienEntities db = new QuanLyThuVienEntities();
        private readonly string salt = "fo3uif08eudfoisdg02837rfhskdjhf0";
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            string loginMessage = string.Empty;
            // Kiểm tra tính đúng đắn của Model
            if (ModelState.IsValid)
            {
                // Hash mật khẩu kèm với salt
                string hashedPassword = (salt + loginModel.Password).MD5Hash();

                // Số lượt đăng nhập lỗi liên tiếp = 3
                // Thời gian đăng nhập lỗi gần nhất = 09:00 -  > 09:05

                // Kiểm tra Email và Password có khớp hay không
                var employee = db.Employee.FirstOrDefault(x => x.Email == loginModel.Email && x.Password == hashedPassword);

                // Đăng nhập thành công
                if (employee != null)
                {
                    Session["UserInfor"] = employee;
                    return RedirectToAction("Index", "Home");
                }
                // Đăng nhập thất bại
                else
                {
                    loginMessage = "Email và Password không khớp";
                }
            }
            // Lỗi validate dữ liệu
            else
            {
                loginMessage = "Email và Password không được để trống";
            }
            return View(loginMessage as object);
        }

        // GET: Logout
        public ActionResult Logout()
        {
            Session.Remove("UserInfor");
            return RedirectToAction("Login");
        }

        // GET: AccessDenied
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}