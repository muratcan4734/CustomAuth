using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using YMS5151_CustomAuth.Models.ORM.Entities;

namespace YMS5151_CustomAuth.Models.ORM.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"server=.;database=YMS5151_CustomAuth;uid=sa;pwd=123;";
        }

        public DbSet<AppUser> Users { get; set; }
    }
}