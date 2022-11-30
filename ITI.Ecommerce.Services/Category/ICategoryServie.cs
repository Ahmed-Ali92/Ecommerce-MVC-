using DTOs;

namespace ITI.Ecommerce.Services
{
    public interface ICategoryServie
    {
        Task add(CategoryDto categoryDto);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
        void Delete(CategoryDto categoryDto);
        void Update(CategoryDto categoryDto);
    }
}
