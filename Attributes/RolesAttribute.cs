using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YMS5151_CustomAuth.Models.ORM.Context;
using YMS5151_CustomAuth.Models.ORM.Entities;

namespace YMS5151_CustomAuth.Attributes
{
    public class RolesAttribute : AuthorizeAttribute
    {
        private string[] _roles;
        public RolesAttribute(params string[] izinVerilenRoller)
        {
            _roles = new string[izinVerilenRoller.Length];
            Array.Copy(izinVerilenRoller, _roles, izinVerilenRoller.Length);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Giriş yapmış olan kullanıcının rolünün, izin verilen rollerden biri olup olmadığını kontrol ediyoruz.

            //İlk olarak aktif kullanıcıyı yakalıyoruz.

            //FormsAuthentication anında kullanıcının emaili httpcontext içerisinde saklanır. Bu session sınıfının üst sınfıdır.
            string email = HttpContext.Current.User.Identity.Name;
            //Emailin boş olmadığından emin oluyoruz.
            if (!string.IsNullOrWhiteSpace(email))
            {
                ProjectContext db = new ProjectContext();
                //Kullanıcıyı veritabnından çekiyoruz.
                AppUser aktifKullanici = db.Users.FirstOrDefault(x => x.Email == email);

                //Kullanıcının rolü, parametrede belirtilen ziin verilen roller arasında var mı onu kontrolü ediyoruz.

                foreach (string role in _roles)
                {
                    if (aktifKullanici.Role.ToString().ToLower() == role.Trim().ToLower())
                    {
                        return true;
                    }
                }


                return false;

            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Error/Unauthorized");
                return false;
            }
            
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Error/Unauthorized");
        }





    }
}