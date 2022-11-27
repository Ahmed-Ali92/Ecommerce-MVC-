using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public float Total { get; set; }


        //Navigation property
        public ICollection<Product> productList { get; set; }
        public Order Order { get; set; }
    }
}
