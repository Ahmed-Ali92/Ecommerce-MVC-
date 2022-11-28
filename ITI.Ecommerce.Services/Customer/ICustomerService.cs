using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ITI.Ecommerce.Services
{
    public interface ICustomerService
    {
        Task add(CustomerDto customerDto);
        Task<IEnumerable<CustomerDto>> GetAll();
        Task<CustomerDto> GetById(string id);
        void Delete(CustomerDto customerDto);
        void Update(CustomerDto customerDto);
    }
}
