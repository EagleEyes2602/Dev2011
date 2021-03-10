using Dev2012.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dev2012.Web.Helpers
{
    public class Authorize
    {
        private static readonly QuanLyThuVienEntities db = new QuanLyThuVienEntities();
        public static bool CheckPermission(string controllerName, string actionName)
        {
            var user = HttpContext.Current.Session["UserInfor"] as Employee;

            // Lấy danh sách chức năng của UserId
            var permissions = from emp in db.Employee
                              join role in db.Roles on emp.RoleId equals role.Id
                              join rolePermission in db.RolePermissions on role.Id equals rolePermission.RoleId
                              join permission in db.Permissions on rolePermission.PermissionId equals permission.Id
                              where emp.Id == user.Id && emp.Status == 1 && emp.IsDelete == false && role.IsDelete == false && permission.IsDelete == false
                              select new { ActionName = permission.ActionName, ControllerName = permission.ControllerName };

            return permissions.Any(x => x.ActionName == actionName && x.ControllerName == controllerName);
        }
    }
}