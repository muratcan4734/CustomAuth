using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YMS5151_CustomAuth.Attributes;

namespace YMS5151_CustomAuth.Controllers
{
    [Roles("Admin","Member")]
    public class MemberController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
    }
}