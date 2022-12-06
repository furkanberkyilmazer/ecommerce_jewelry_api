using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repository.Seeds
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
               new User { Id = 1, Name = "Berk",Surname="Yılmazer", Email="furkan_berk_yilmazer@hotmail.com", Username="furkanberk", Password="123456" , RoleId = 1,
               CreatedDate= DateTime.Now},
              new User { Id = 2, Name = "furkan", Surname = "Yılmazer", Email = "berkyilmazer@hotmail.com", Username = "brkylmzr", Password = "1234567", RoleId = 2 ,
                  CreatedDate = DateTime.Now
              }
               );
        }
    }
}
