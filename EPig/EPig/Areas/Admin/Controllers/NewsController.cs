using EPig.Resposity.Interface;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPig.Areas.Admin.Controllers
{
    /// <summary>
    /// 新闻管理
    /// </summary>
    public class NewsController : Controller
    {
        //Ioc注入
        [Inject]
        public INewsRepository NewsRepository { get; set; }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Remove()
        {
            return RedirectToAction("List");
        }
    }
}
