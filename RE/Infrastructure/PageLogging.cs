using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RE.Infrastructure
{
    public class PageViewLoggingAttribute : ActionFilterAttribute
    {
        private static readonly TimeSpan pageViewDumpToDatabaseTimeSpan = new TimeSpan(0, 0, 10);

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            REEntities _se = new REEntities();

            Logging myLogging = new Logging();

            myLogging.ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            myLogging.ActionName = filterContext.ActionDescriptor.ActionName;
            myLogging.Date = TimeZoneInfo.ConvertTime(filterContext.HttpContext.Timestamp, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            myLogging.IPAddress = filterContext.HttpContext.Request.UserHostAddress;
            myLogging.ActionParameters = "";

            myLogging.AbsoluteUri = filterContext.HttpContext.Request.UrlReferrer?.AbsoluteUri;


            foreach (var pram in filterContext.ActionParameters)
            {
                myLogging.ActionParameters += pram + " ";
            }

            myLogging.ActionParameters = myLogging.ActionParameters.Trim();

            _se.Loggings.Add(myLogging);
            try
            {
                _se.SaveChanges();
            }
            catch
            {
                return;

            }

        }





    }
}