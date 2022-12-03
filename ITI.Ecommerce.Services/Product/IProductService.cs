using DTOs;

namespace ITI.Ecommerce.Services
{
    public interface IProductService
    {
        Task add(ProductDto productDto);
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> GetById(int id);
        Task<IEnumerable<ProductDto>> GetByCategoryId(int id);
        void Delete(ProductDto productDto);
        void Update(ProductDto productDto);
    }
}
