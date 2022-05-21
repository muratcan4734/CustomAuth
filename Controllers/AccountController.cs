using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YMS5151_CustomAuth.Models.DTO;
using YMS5151_CustomAuth.Models.ORM.Context;
using YMS5151_CustomAuth.Models.ORM.Entities;

namespace YMS5151_CustomAuth.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                ProjectContext db = new ProjectContext();
                AppUser kullanici = db.Users.Where(x=>x.Email==User.Identity.Name).FirstOrDefault();

                if (kullanici.Role == Role.Admin)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (kullanici.Role == Role.Member)
                {
                    return RedirectToAction("Index", "Member");
                }
                else
                {
                    return RedirectToAction("Register");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM data)
        {
            if (ModelState.IsValid)
            {
                using (ProjectContext db = new ProjectContext())
                {
                    AppUser kullanici = db.Users.FirstOrDefault(x => x.Email == data.Email && x.Password == data.Password);

                    if (kullanici != null)
                    {
                  
                        FormsAuthentication.SetAuthCookie(kullanici.Email, data.IsPersistent);

                        if (kullanici.Role==Role.Admin)
                        {
                            return RedirectToAction("Index","Home");
                        }
                        else if (kullanici.Role==Role.Member)
                        {
                            return RedirectToAction("Index", "Member");
                        }
                        else
                        {
                            return RedirectToAction("Register");
                        }

                        
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}