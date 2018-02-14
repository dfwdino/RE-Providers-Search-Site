using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RE.Controllers
{
    public class LoginController : Controller
    {
        private REEntities db = new REEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User loginuser)
        {

            User user = db.Users.Where(m => m.LoginName == loginuser.LoginName && m.Password == loginuser.Password && loginuser.Disable == false).SingleOrDefault();
            if (user != null)
            {
                HttpCookie siteCookie = new HttpCookie("RE");

                siteCookie.Values.Add("HasAccess", "true");
                siteCookie.Values.Add("ID", user.ID.ToString());
                siteCookie.Expires = DateTime.Now.Date.AddDays(1);
                this.ControllerContext.HttpContext.Response.Cookies.Add(siteCookie);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(loginuser.LoginName, "Can't find user");

            return View();
        }

    }
}