using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }

        public DateTime DateEntered { get; set; }

        //Navigation property

        public ICollection<Order> orderList { get; set; }

    }
}
