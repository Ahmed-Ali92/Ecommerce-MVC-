using DTOs;
using Microsoft.EntityFrameworkCore;

namespace ITI.Ecommerce.Services
{
    public class ProductImageService : IProductImageService
    {

        private readonly ApplicationDbContext _context;
        public ProductImageService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task add(ProductImageDto productImageDto)
        {
            ProductImage productImage = new ProductImage()
            {
                Path = productImageDto.Path,
                ProductID = productImageDto.ProductID,
                IsDeleted = productImageDto.IsDeleted
            };

            await _context.ProductImages.AddAsync(productImage);
            _context.SaveChanges();
        }

        public void Delete(ProductImageDto productImageDto)
        {
            ProductImage productImage = new ProductImage()
            {
                ID = productImageDto.ID,
                Path = productImageDto.Path,
                ProductID = productImageDto.ProductID,
                IsDeleted = true
            };
            _context.Update(productImage);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<ProductImageDto>> GetAll()
        {
            List<ProductImageDto> productImageDtoList = new List<ProductImageDto>();

            var productImages = await _context.ProductImages.Where(i => i.IsDeleted == true).ToListAsync();

            foreach (var img in productImages)
            {
                ProductImageDto productImageDto = new ProductImageDto()
                {
                    ID = img.ID,
                    Path = img.Path,
                    ProductID = img.ProductID,
                    IsDeleted = img.IsDeleted
                };
                productImageDtoList.Add(productImageDto);

            }
            return productImageDtoList;
        }

        public async Task<ProductImageDto> GetById(int id)
        {
            var productImage = await _context.ProductImages.Where(i => i.ID == id).SingleOrDefaultAsync();

            if (productImage == null)
            {
                throw new Exception("this image not found");
            }
            else
            {
                ProductImageDto productImageDto = new ProductImageDto()
                {
                    ID = productImage.ID,
                    Path = productImage.Path,
                    ProductID = productImage.ProductID,
                    IsDeleted = productImage.IsDeleted
                };
                return productImageDto;
            }
        }

        public async Task<IEnumerable<ProductImageDto>> GetByProductId(int id)
        {
            var productImages = await _context.ProductImages.Where(i => i.ProductID == id).ToListAsync();
            List<ProductImageDto> productImageDtoList = new List<ProductImageDto>();
            foreach (var img in productImages)
            {
                ProductImageDto productImageDto = new ProductImageDto()
                {
                    ID = img.ID,
                    Path = img.Path,
                    ProductID = img.ProductID,
                    IsDeleted = img.IsDeleted
                };
                productImageDtoList.Add(productImageDto);

            }
            return productImageDtoList;
        }

        public void Update(ProductImageDto productImageDto)
        {
            ProductImage productImage = new ProductImage()
            {
                ID = productImageDto.ID,
                Path = productImageDto.Path,
                ProductID = productImageDto.ProductID,
                IsDeleted = true
            };
            _context.Update(productImage);
            _context.SaveChanges();
        }
    }
}
