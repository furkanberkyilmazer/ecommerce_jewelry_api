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
    internal class RoleSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                 new Role { Id = 1,Name = "Kullanıcı"},
                 new Role { Id = 2,Name="Admin" } ,
                 new Role { Id = 3, Name = "Engel" }
                 );
        }
    }
}
