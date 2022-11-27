﻿using DTOs;
using ITI.Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Ecommerce.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task add(CustomerDto customerDto)
        {
            Customer customer = new Customer()
            {
                NameAR = customerDto.NameAR,
                NameEN = customerDto.NameEN,
                IsDeleted = customerDto.IsDeleted,
                FullName = customerDto.FullName,
                Address =   customerDto.Address,
                MobileNumber = customerDto.MobileNumber ,
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
                ID = customerDto.ID,
                NameAR = customerDto.NameAR,
                NameEN = customerDto.NameEN,
                IsDeleted = true,
                FullName = customerDto.FullName,
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
                    ID = customer.ID,
                    NameAR = customer.NameAR,
                    NameEN = customer.NameEN,
                    IsDeleted = customer.IsDeleted,
                    FullName = customer.FullName,
                    Address = customer.Address,
                    MobileNumber = customer.MobileNumber,
                    Email = customer.Email,
                    DateEntered = customer.DateEntered
                };
                customerDtosList.Add(customerDto);
            }
            return customerDtosList;
        }

        public async Task<CustomerDto> GetById(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(o => o.ID == id);
            if (customer == null)
            {
                throw new Exception("this customer not found");
            }
            else
            {
                CustomerDto customerDto = new CustomerDto()
                {
                    ID = customer.ID,
                    NameAR = customer.NameAR,
                    NameEN = customer.NameEN,
                    IsDeleted = customer.IsDeleted,
                    FullName = customer.FullName,
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
                ID = customerDto.ID,
                NameAR = customerDto.NameAR,
                NameEN = customerDto.NameEN,
                IsDeleted = customerDto.IsDeleted,
                FullName = customerDto.FullName,
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
