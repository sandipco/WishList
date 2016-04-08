using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace WishListWebService.Models
{
    public class WishListContext:IdentityDbContext<WishListUser> 
    {
        public WishListContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<WishListUser> Users { get; set; }
        public DbSet<WishList> WishLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var constr = Startup.Configuration["Data:WishListConnection"];
            optionsBuilder.UseSqlServer(constr);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
