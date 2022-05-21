using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YMS5151_CustomAuth.Models.ORM.Entities
{

    public enum Role
    {
        None = 0,
        Admin = 1,
        Member = 3
    }

    public class AppUser
    {
        [Key]
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public Role Role { get; set; }
    }
}