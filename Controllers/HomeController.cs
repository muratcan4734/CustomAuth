using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YMS5151_CustomAuth.Attributes;

namespace YMS5151_CustomAuth.Controllers
{
    //using YMS5151_CustomAuth.Attributes;

    [RolesAttribute("Admin")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}