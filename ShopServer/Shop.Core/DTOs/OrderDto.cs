using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.DTOs
{
    public class OrderDto : BaseDto
    {

        public int Price { get; set; }
        public int Piece { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int AddressId { get; set; }
    }
}
