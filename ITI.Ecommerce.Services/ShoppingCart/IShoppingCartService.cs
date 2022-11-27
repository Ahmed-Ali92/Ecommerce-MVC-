using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Services
{
    public interface IShoppingCartService
    {
        Task add(ShoppingCartDto shoppingCartDto);
        Task<IEnumerable<ShoppingCartDto>> GetAll();
        Task<ShoppingCartDto> GetById(int id);
        void Delete(ShoppingCartDto shoppingCartDto);
        void Update(ShoppingCartDto shoppingCartDto);
    }
}
