using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPig.Areas.Admin.Controllers
{
    /// <summary>
    /// 新闻类型管理
    /// </summary>
    public class ArticleTypeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
