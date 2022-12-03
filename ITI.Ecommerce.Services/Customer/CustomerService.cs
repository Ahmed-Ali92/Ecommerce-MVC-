using DTOs;
using Microsoft.EntityFrameworkCore;

namespace ITI.Ecommerce.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context ;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task add(CustomerDto customerDto)
        {
            Customer customer = new Customer()
            {

                IsDeleted = customerDto.IsDeleted,
                UserName = customerDto.UserName,
                Address = customerDto.Address,
                MobileNumber = customerDto.MobileNumber,
                Email = customerDto.Email,
                DateEntered = customerDto.DateEntered
            };
            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();
        }

        public void Delete(CustomerDto customerDto)
        {
            Customer customer = new Customer()
            {
                Id = customerDto.Id,

                IsDeleted = true,
                UserName = customerDto.UserName,
                Address = customerDto.Address,
                MobileNumber = customerDto.MobileNumber,
                Email = customerDto.Email,
                DateEntered = customerDto.DateEntered
            };
            _context.Update(customer);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            List<CustomerDto> customerDtosList = new List<CustomerDto>();
            var Customiers = await _context.Customers.Where(c => c.IsDeleted == false).ToListAsync();
            foreach (var customer in Customiers)
            {
                CustomerDto customerDto = new CustomerDto()
                {
                    Id = customer.Id,

                    IsDeleted = customer.IsDeleted,
                    UserName = customer.UserName,
                    Address = customer.Address,
                    MobileNumber = customer.MobileNumber,
                    Email = customer.Email,
                    DateEntered = customer.DateEntered
                };
                customerDtosList.Add(customerDto);
            }
            return customerDtosList;
        }

        public async Task<CustomerDto> GetById(string id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(o => o.Id == id);
            if (customer == null)
            {
                throw new Exception("this customer not found");
            }
            else
            {
                CustomerDto customerDto = new CustomerDto()
                {
                    Id = customer.Id,

                    IsDeleted = customer.IsDeleted,
                    UserName = customer.UserName,
                    Address = customer.Address,
                    MobileNumber = customer.MobileNumber,
                    Email = customer.Email,
                    DateEntered = customer.DateEntered
                };
                return customerDto;
            }
        }

        public void Update(CustomerDto customerDto)
        {
            Customer customer = new Customer()
            {
                Id = customerDto.Id,

                IsDeleted = customerDto.IsDeleted,
                UserName = customerDto.UserName,
                Address = customerDto.Address,
                MobileNumber = customerDto.MobileNumber,
                Email = customerDto.Email,
                DateEntered = customerDto.DateEntered

            };

            _context.Update(customer);
            _context.SaveChanges();
        }
    }
}
