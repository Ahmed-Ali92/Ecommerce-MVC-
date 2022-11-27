using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    // add ShoppingCartDto property
    public class ShoppingCartDto
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public float Total { get; set; }
        public string NameAR { set; get; }
        public string NameEN { set; get; }
        public bool IsDeleted { get; set; }


    }
}
