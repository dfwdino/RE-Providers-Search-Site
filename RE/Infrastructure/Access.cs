using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RE.Infrastructure
{
    public class StrackerAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            HttpCookie cookie = HttpContext.Current.Request.Cookies["Stacking"];

            if (cookie == null || !cookie.HasKeys)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Index",
                    area = ""
                }));
            }
           
        }


        public static HttpRequest GetHttpRequest()
        {
            return HttpContext.Current.Request;
        }
    }
}