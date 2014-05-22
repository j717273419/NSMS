using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPig.Resposity.Interface;
using Ninject;
using EPig.Areas.Admin.Models;

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

        [ChildActionOnly]
        public ActionResult ParentType()
        {
            var result = (from item in CategoryRepository.GetAllCategorys()
                          select new CategoryDropDownItem { ID = item.ID.Value.ToString()
                              , Name = item.Name }).ToList();
            return View(result);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CategoryAdd category)
        {

            TempData["Msg"] = "添加成功";
            return RedirectToAction("List");
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string controller)
        {
            TempData["Msg"] = "添加成功";

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Remove()
        {
            TempData["Msg"] = "删除成功";
            return RedirectToAction("List");
        }
    }
}
