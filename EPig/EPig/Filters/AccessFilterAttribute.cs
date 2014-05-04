using EPig.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPig.Filters
{
    public class AccessFilterAttribute : AuthorizeAttribute
    {
        private const String Key = "X-USER-ACCOUNT-KEY";
        private List<UserRoleType> Types;

        public AccessFilterAttribute()
        {
            Types = new List<UserRoleType>();
            Types.Add(UserRoleType.None);
        }

        public AccessFilterAttribute(params UserRoleType[] type)
        {
            Types = type.ToList();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            object obj = httpContext.Session[Key];
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            UrlHelper UrlHelp = new UrlHelper(filterContext.RequestContext);
            String url = UrlHelp.Action("Login", "User");
            filterContext.Result = new RedirectResult(url);
        }
    }
}