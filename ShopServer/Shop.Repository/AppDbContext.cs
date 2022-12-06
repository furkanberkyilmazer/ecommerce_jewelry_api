using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Shop.Repository.Configurations;
using System.Linq;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Core.Models;

namespace Shop.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
          
            //modelBuilder.Entity<Basket>().HasData(new Basket()
            //{
            //    Id = 4,
            //    ProductId = 2,
            //    UserId = 1

            //});  //bu da seed klası kullanmadan ekleme işlemi örneği

           
            base.OnModelCreating(modelBuilder);
        }


    }
}
