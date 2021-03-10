using Dev2012.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dev2012.Web.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        private readonly QuanLyThuVienEntities db = new QuanLyThuVienEntities();
        // Request bắt đầu vào filter
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Authentication
            // Kiểm tra session của người dùng
            if (filterContext.HttpContext.Session["UserInfor"] == null)
            {
                // Redirect To Login
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Authentication",
                    action = "Login"
                }));
            }
            else
            {
                var user = filterContext.HttpContext.Session["UserInfor"] as Employee;
                // Authorization
                // Lấy Chức năng (ControllerName & ActionName) mà user đang muốn truy cập
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string actionName = filterContext.ActionDescriptor.ActionName;

                // Lấy danh sách chức năng của UserId
                var permissions = from emp in db.Employee
                                  join role in db.Roles on emp.RoleId equals role.Id
                                  join rolePermission in db.RolePermissions on role.Id equals rolePermission.RoleId
                                  join permission in db.Permissions on rolePermission.PermissionId equals permission.Id
                                  where emp.Id == user.Id && emp.Status == 1 && emp.IsDelete == false && role.IsDelete == false && permission.IsDelete == false
                                  select new { ActionName = permission.ActionName, ControllerName = permission.ControllerName };

                // So sánh chức năng muốn truy cập có nằm trong phạm vi cho phép hay không
                bool access = permissions.Any(x => x.ActionName == actionName && x.ControllerName == controllerName);
                if (!access)
                {
                    // Redirect To Access Denied
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Authentication",
                        action = "AccessDenied"
                    }));
                }
            }

            base.OnActionExecuting(filterContext);
        }

        // Request đã đi qua OnActionExecuting
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Log("OnActionExecuted", filterContext.RouteData);
        }

        // Response đang đi vào filter
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Log("OnResultExecuting", filterContext.RouteData);
        }

        // Response đã đi qua OnResultExecuting
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //Log("OnResultExecuted", filterContext.RouteData);
        }

        //private void Log(string methodName, RouteData routeData)
        //{
        //    var controllerName = routeData.Values["controller"];
        //    var actionName = routeData.Values["action"];
        //    var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
        //    Debug.WriteLine(message, "Action Filter Log");
        //}
    }
}