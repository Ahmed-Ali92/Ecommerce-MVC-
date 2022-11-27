using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Services
{
    public interface IOrderService
    {
        Task add(OrderDto orderDto);
        Task<IEnumerable<OrderDto>> GetAll();
        Task<OrderDto> GetById(int id); 
         void Delete(OrderDto orderDto);
        void Update(OrderDto orderDto);
    }
}
