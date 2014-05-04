using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPig.Areas.Admin.Controllers
{
    /// <summary>
    /// 分类管理
    /// </summary>
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
