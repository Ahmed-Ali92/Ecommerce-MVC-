using DTOs;
using Microsoft.EntityFrameworkCore;

namespace ITI.Ecommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public ProductService(ApplicationDbContext context)
        {

        }

        public async Task add(ProductDto productDto)
        {
            Product product = new Product()
            {

                NameAR = productDto.NameAR,
                NameEN = productDto.NameEN,
                Description = productDto.Description,
                CategoryID = productDto.CategoryID,
                Quantity = productDto.Quantity,
                UnitPrice = productDto.UnitPrice,
                Discount = productDto.Discount,
                TotalPrice = productDto.TotalPrice,
                IsDeleted = productDto.IsDeleted,
            };

            await _context.Products.AddAsync(product);
            _context.SaveChanges();
        }

        public void Delete(ProductDto productDto)
        {
            Product product = new Product()
            {
                ID = productDto.ID,
                NameAR = productDto.NameAR,
                NameEN = productDto.NameEN,
                Description = productDto.Description,
                CategoryID = productDto.CategoryID,
                Quantity = productDto.Quantity,
                UnitPrice = productDto.UnitPrice,
                Discount = productDto.Discount,
                TotalPrice = productDto.TotalPrice,
                IsDeleted = true,
            };

            _context.Update(product);
            _context.SaveChanges();

        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            List<ProductDto> productDtoList = new List<ProductDto>();

            var products = await _context.Products.Where(p => p.IsDeleted == false).ToListAsync();

            foreach (var product in products)
            {
                ProductDto productDto = new ProductDto()
                {
                    ID = product.ID,
                    NameAR = product.NameAR,
                    NameEN = product.NameEN,
                    Description = product.Description,
                    CategoryID = product.CategoryID,
                    UnitPrice = product.UnitPrice,
                    Quantity = product.Quantity,
                    Discount = product.Discount,
                    TotalPrice = product.TotalPrice,
                    IsDeleted = product.IsDeleted,


                };
                productDtoList.Add(productDto);

            }

            return productDtoList;
        }

        public async Task<IEnumerable<ProductDto>> GetByCategoryId(int id)
        {
            List<ProductDto> productDtoList = new List<ProductDto>();
            var product = await _context.Products.SingleOrDefaultAsync(p => p.CategoryID == id);
            if (product == null)
            {
                throw new Exception("this product is not found ");
            }
            else
            {


                ProductDto productDto = new ProductDto()
                {
                    ID = product.ID,
                    NameAR = product.NameAR,
                    NameEN = product.NameEN,
                    Description = product.Description,
                    CategoryID = product.CategoryID,
                    UnitPrice = product.UnitPrice,
                    Quantity = product.Quantity,
                    Discount = product.Discount,
                    TotalPrice = product.TotalPrice,
                    IsDeleted = product.IsDeleted,
                };
                return productDtoList;
            }
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.ID == id);
            if (product == null)
            {
                throw new Exception("this product is not found ");
            }
            else
            {

                ProductDto productDto = new ProductDto()
                {
                    ID = product.ID,
                    NameAR = product.NameAR,
                    NameEN = product.NameEN,
                    Description = product.Description,
                    CategoryID = product.CategoryID,
                    UnitPrice = product.UnitPrice,
                    Quantity = product.Quantity,
                    Discount = product.Discount,
                    TotalPrice = product.TotalPrice,
                    IsDeleted = product.IsDeleted,
                };
                return productDto;
            }
        }

        public void Update(ProductDto productDto)
        {
            Product product = new Product()
            {
                ID = productDto.ID,
                NameAR = productDto.NameAR,
                NameEN = productDto.NameEN,
                Description = productDto.Description,
                CategoryID = productDto.CategoryID,
                Quantity = productDto.Quantity,
                UnitPrice = productDto.UnitPrice,
                Discount = productDto.Discount,
                TotalPrice = productDto.TotalPrice,
                IsDeleted = productDto.IsDeleted,
            };

            _context.Update(product);
            _context.SaveChanges();
        }
    }
}
