using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Models
{
    public class Customer : IdentityUser
    {
       
        public string UserName { get; set; }
       
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }

        public DateTime DateEntered { get; set; }
      

        public bool IsDeleted { set; get; }


        //Navigation property

        public ICollection<Order> orderList { get; set; }

    }
}
