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
    /// 用户管理
    /// </summary>
    public class UserController : Controller
    {
        //Ioc注入
        [Inject]
        public IUserRepository UserRepository { get; set; }

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
    }
}
