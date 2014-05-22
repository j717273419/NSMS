using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPig.Resposity.Interface;
using Ninject;

namespace EPig.Areas.Admin.Controllers
{
    /// <summary>
    /// 分类管理
    /// </summary>
    public class CategoryController : Controller
    {
        //ioc注入
        [Inject]
        public ICategoryRepository CategoryRepository { get; set; }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }
    }
}
