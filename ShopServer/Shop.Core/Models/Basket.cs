using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class Basket
    {
        public int Id { get; set; }

        public int Piece { get; set; }    

        public int UserId { get; set; }

        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
