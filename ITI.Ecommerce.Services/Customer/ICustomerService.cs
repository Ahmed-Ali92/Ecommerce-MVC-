using DTOs;


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
