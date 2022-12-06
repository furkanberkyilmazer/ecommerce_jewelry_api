using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }


        public ICollection<Basket>? Baskets { get; set; }

        public ICollection<Order>? Orders { get; set; }

        public ICollection<Address>? Addresses { get; set; }
 
    }
}
