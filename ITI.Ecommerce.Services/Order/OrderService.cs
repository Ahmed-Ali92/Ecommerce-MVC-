﻿using DTOs;
using ITI.Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public OrderService(ApplicationDbContext context)
        {
            
        }
        public async Task add(OrderDto orderDto)
        {
            Order order = new Order()
            {
               
                CustomerId = orderDto.CustomerId,
                PaymentId = orderDto.PaymentId,
                OrderDate = orderDto.OrderDate,
                IsDeleted = orderDto.IsDeleted,
                ShoppingCartId = orderDto.ShoppingCartId
            };

           await _context.Orders.AddAsync(order);
            _context.SaveChanges();
        }

        public void Delete(OrderDto orderDto)
        {
            Order order = new Order()
            {
                ID = orderDto.ID,
                CustomerId = orderDto.CustomerId,
                PaymentId = orderDto.PaymentId,
                OrderDate = orderDto.OrderDate,
                IsDeleted = true,
                ShoppingCartId = orderDto.ShoppingCartId
            };
            _context.Update(order);
            _context.SaveChanges();
            
        }

        public async Task <IEnumerable<OrderDto>> GetAll()
        {
            List<OrderDto> orderList=new List<OrderDto>();

           
           var orders =  await  _context.Orders.Where(o=>o.IsDeleted==false).ToListAsync();
            foreach (var order in orders)
            {
                OrderDto orderDto = new OrderDto();
                orderDto.ID = order.ID  ;
                orderDto.CustomerId = order.CustomerId ;
                orderDto.PaymentId = order.PaymentId  ;
                orderDto.OrderDate = order.OrderDate ;
                orderDto.IsDeleted = order.IsDeleted  ;
                orderDto.ShoppingCartId = order.ShoppingCartId; 
                orderList.Add(orderDto);
            }
            return orderList;
        }

        public async Task<OrderDto> GetById(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(o => o.ID == id);
            if (order == null)
            {
                throw new Exception("this order is not found");
            }
            else
            {
                OrderDto orderDto = new OrderDto()
                {
                    ID = order.ID,
                    CustomerId = order.CustomerId,
                    PaymentId = order.PaymentId,
                    OrderDate = order.OrderDate,
                    IsDeleted = order.IsDeleted,
                    ShoppingCartId = order.ShoppingCartId
                };
                return orderDto;
            }
        }

        public void Update(OrderDto orderDto)
        {
            Order order = new Order()
            {
                ID = orderDto.ID,
                CustomerId = orderDto.CustomerId,
                PaymentId = orderDto.PaymentId,
                OrderDate = orderDto.OrderDate,
                IsDeleted = orderDto.IsDeleted,
                ShoppingCartId = orderDto.ShoppingCartId
            };
            _context.Update(order);
            _context.SaveChanges();
        }
    }
}
