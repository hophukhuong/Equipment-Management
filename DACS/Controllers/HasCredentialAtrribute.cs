using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DACS.Controllers
{
    public class HasCredentialAtrribute : AuthorizeAttribute
    {
        public string RoleCode { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            List<string> credential = this.getCredentialByLoogedInMember();
            if (credential != null && credential.Contains(this.RoleCode))
            {
                return true;
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Home/NotCredential");

        }
        private List<string> getCredentialByLoogedInMember()
        {
            return (List<string>)HttpContext.Current.Session["Credential"];
        }
    }
}