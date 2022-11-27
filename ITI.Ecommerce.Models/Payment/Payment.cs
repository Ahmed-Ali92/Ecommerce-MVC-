using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public string PaymentType { get; set; }
        public bool IsAllowed { get; set; }

        //Navigation property
        public Order Order { get; set; }

    }
}
