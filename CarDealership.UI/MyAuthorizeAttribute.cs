using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CarDealership.UI
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public MyAuthorizeAttribute()
        {
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
#if DEBUG
            return false;
#else
        return base.IsAuthorized(actionContext);
#endif
        }
    }
}