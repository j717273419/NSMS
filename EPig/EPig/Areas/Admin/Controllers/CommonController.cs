using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPig.Areas.Admin.Controllers
{
    /// <summary>
    /// 公共控制器
    /// </summary>
    public class CommonController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
