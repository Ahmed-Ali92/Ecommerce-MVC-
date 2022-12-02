using Microsoft.AspNetCore.Mvc;
using DTOs;
using ITI.Ecommerce.Services;
namespace ITI.Ecommerce.Presenation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
       public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            List<CustomerDto> li=new List<CustomerDto>();
            // var User = await _customerService.GetAll();
            CustomerDto dto = new CustomerDto()
            {
                NameAR = "احمد",
                NameEN = "Ahmed",
                FullName = "ahmed ali",
                Address = "sohage",
                Email = "ahmed@gmail",
                MobileNumber = "12020920"
            };
            li.Add(dto);

            return View(li);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(string UserName)
        {
            var User = await _customerService.GetById(UserName);

            return View(User);
        }
        [HttpPost]
        public IActionResult UpdateUser(CustomerDto customerDto)
        {
              _customerService.Update(customerDto);

            return RedirectToAction("GetAllUser","Customer");
        }



    }
}
