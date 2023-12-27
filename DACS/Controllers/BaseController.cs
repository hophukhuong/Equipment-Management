
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Member = DACS.Context.Member;

namespace DACS.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        public Member member;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Member"] == null && filterContext.RouteData.Values["controller"].ToString() != "Member")
            {
                filterContext.Result = new RedirectResult("/Member/Login");
            }
            else
            {
                member = (Member)Session["Member"];
            }
            base.OnActionExecuting(filterContext);
        }

    }
}