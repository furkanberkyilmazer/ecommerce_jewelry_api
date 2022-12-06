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
    internal class AddressSeed : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
               new Address { Id = 1, Country = "Türkiye", Province = "İstanbul", District = "Kağıthane", Content = "Seyrantepe mahallesi barbaros caddesi ", Title = "ev adresi", UserId = 1 },
              new Address { Id = 2, Country = "Türkiye", Province = "İstanbul", District = "Alibeyköy", Content = "cengiztopel caddesi ", Title = "evim", UserId = 2 }
               );
        }
    }
}
