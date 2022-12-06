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
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "İnci Kolye",
                    Stock=50,
                    Price=100,
                    Description="Çok güzel bir kolye.",
                    ImageUrl= "https://images.osmanlipazar.com/ozel-tasarim-inci-kolye-dogal-tas-kolye-osmanli-pazar-19536-49-O.jpg",
                    CreatedDate= DateTime.Now

                },
                new Product {
                    Id = 2,
                    CategoryId = 2,
                    Name = "Altın Bileklik",
                    Stock = 40,
                    Price = 2000,
                    Description = "Çok güzel bir bileklik.",
                    ImageUrl = "https://fns.modanisa.com/r/pro2/2021/06/07/n-kelepce-bileklik--altin--aydin-bijuteri-8004075-1.jpg",
                    CreatedDate = DateTime.Now
                }
                ) ;
        }
    }
}
