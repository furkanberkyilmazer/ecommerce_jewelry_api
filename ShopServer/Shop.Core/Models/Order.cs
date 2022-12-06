using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class Order : BaseEntity
    {
        public int Price { get; set; }
        public int Piece { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int AddressId { get; set; }

        public Address Address { get; set; }





    }
}
