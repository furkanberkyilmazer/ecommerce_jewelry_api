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
    internal class BasketSeed : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasData(
                 new Basket { Id = 1,Piece=50, ProductId=1 , UserId = 1},
                 new Basket { Id = 2, Piece = 40, ProductId = 2, UserId = 1 },
                  new Basket { Id = 3, Piece = 26, ProductId = 1, UserId = 2 }
                 );
        }
    }
}
