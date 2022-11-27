using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
