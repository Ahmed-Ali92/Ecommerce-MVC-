using Microsoft.AspNetCore.Identity;

namespace DTOs
{
    // add CustomerDto property
    public class CustomerDto : IdentityUser
    {
        public string Address { get; set; }
        public string MobileNumber { get; set; }


        public DateTime DateEntered { get; set; }


        public bool IsDeleted { set; get; }


        //Navigation property

        public ICollection<OrderDto> orderList { get; set; }
    }
}
