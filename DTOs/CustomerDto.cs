﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    // add CustomerDto property
    public class CustomerDto
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string NameAR { set; get; }
        public string NameEN { set; get; }
        public bool IsDeleted { set; get; }
        public DateTime DateEntered { get; set; }

        public ICollection<OrderDto> orderList { get; set; }
    }
}
