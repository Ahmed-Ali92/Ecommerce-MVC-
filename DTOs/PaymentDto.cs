using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PaymentDto
    {
        public int ID { get; set; }
        public string PaymentType { get; set; }
        public bool IsAllowed { get; set; }
    }
}
