using Dev2012.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dev2012.Web.Controllers
{
    [AuthenticationFilter]
    public class BaseController : Controller
    {
    }
}