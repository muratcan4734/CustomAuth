using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YMS5151_CustomAuth.Models.DTO
{
    public class LoginVM
    {

        [Required(ErrorMessage = "Parola Giriniz")]
        public string Password { get; set; }


        [EmailAddress(ErrorMessage = "E-Posta Formatında Giriş Yapınız")]
        [Required(ErrorMessage = "E-Posta Giriniz")]
        public string Email { get; set; }

        
        public bool IsPersistent { get; set; }
    }
}