﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; }
        public int ShoppingCartId { get; set; }


        //Navigation property

        public ShoppingCart ShoppingCart { get; set; }
        public ICollection<Customer> customersList  { get; set; }
        public Payment Payment { get; set; }
    }
}
