using DTOs;
using ITI.Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ITI.Ecommerce.Services
{
    public class CategoryService : ICategoryServie
    {
        private readonly ApplicationDbContext _context;
        public CategoryService()
        {
            _context = new ApplicationDbContext();
        }
        public async Task add(CategoryDto categoryDto)
        {
            Category category = new Category()
            {
                NameAR = categoryDto.NameAR,
                NameEN = categoryDto.NameEN,
                IsDeleted=categoryDto.IsDeleted,
            };
            await _context.Categories.AddAsync(category);
            _context.SaveChanges();
        }

        public void Delete(CategoryDto categoryDto)
        {
            Category category = new Category()
            {
                ID = categoryDto.ID,
                NameAR = categoryDto.NameAR,
                NameEN = categoryDto.NameEN,
                IsDeleted = true,
            };
            _context.Update(category);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            List<CategoryDto> categoryDtosList = new List<CategoryDto>();
            var categories = await _context.Categories.Where(c=>c.IsDeleted==false).ToListAsync();
            foreach (var category in categories)
            {
                CategoryDto categoryDto = new CategoryDto()
                {
                    ID=category.ID,
                    NameAR=category.NameAR,
                    NameEN =category.NameEN,
                    IsDeleted=category.IsDeleted,
                };
                categoryDtosList.Add(categoryDto);
            }
            return categoryDtosList;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(o => o.ID == id);
            if (category == null)
            {
                throw new Exception("this category not found");
            }
            else
            {
                CategoryDto categoryDto = new CategoryDto()
                {
                    ID = category.ID,
                    NameAR = category.NameAR,
                    NameEN = category.NameEN,
                    IsDeleted = category.IsDeleted,
                };
                return categoryDto;
            }
        }

        public void Update(CategoryDto categoryDto)
        {
            Category category = new Category()
            {
                ID = categoryDto.ID,
                NameAR = categoryDto.NameAR,
                NameEN = categoryDto.NameEN,
                IsDeleted = categoryDto.IsDeleted,
            };

            _context.Update(category);
            _context.SaveChanges();
        }
    }
}
