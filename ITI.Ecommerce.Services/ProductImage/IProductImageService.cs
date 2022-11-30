using DTOs;

namespace ITI.Ecommerce.Services
{
    public interface IProductImageService
    {
        Task add(ProductImageDto productImageDto);
        Task<IEnumerable<ProductImageDto>> GetAll();
        Task<ProductImageDto> GetById(int id);
        Task<IEnumerable<ProductImageDto>> GetByProductId(int id);
        void Delete(ProductImageDto productImageDto);
        void Update(ProductImageDto productImageDto);

    }
}
