using Microsoft.AspNetCore.Mvc;
using DTOs;
using ITI.Ecommerce.Services;
using ITI.Ecommerce.Models;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;
using ITI.Ecommerce.Presenation;

namespace ITI.Ecommerce.Presenation.Controllersss
{
    public class ProductController : Controller
    {
        public IProductService _pro;
        public IProductImageService _img;
        public IConfiguration con;



        public ProductController(IProductService pro, IProductImageService img, IConfiguration _con)
        {

            _pro = pro;
            _img = img;
            con = _con;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {


            var Proudicts = await _pro.GetAllCat();
            ViewBag.Cat = Proudicts.Select(i => new SelectListItem(i.NameEN, i.ID.ToString()));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductModel dto)

        {
            ICollection<ProductImage> images = new List<ProductImage>();
            foreach (IFormFile file in dto.Images)
            {
                string NewName = Guid.NewGuid().ToString() + file.FileName;

                ProductImage prodImg = new ProductImage()
                {
                    Path = NewName,
                    ProductID = dto.ID,
                    IsDeleted = false
                };
                images.Add(prodImg);
                FileStream fs = new FileStream(
                    Path.Combine(Directory.GetCurrentDirectory(),
                    "Content", "Images", "Product", NewName)
                    , FileMode.OpenOrCreate, FileAccess.ReadWrite);
                file.CopyTo(fs);
                fs.Position = 0;
            }
            ProductDto dtos = new ProductDto()
            {
                NameAR = dto.NameAR,
                NameEN = dto.NameEN,
                Brand = dto.Brand,
                Description = dto.Description,
                CategoryID = dto.CategoryID,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
                IsDeleted = false,
                Discount=dto.Discount,
                TotalPrice = dto.UnitPrice-dto.Discount,
                productImageList = images

            };



            await _pro.add(dtos);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageIndex = 1, int pageSize = 5)
        {
            var Proudicts = await _pro.GetAll();
            var Page = Proudicts.ToPagedList(pageIndex, pageSize);
            return View(Page);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int P)
        {
            var Proudicts = await _pro.GetAllCat();
            ViewBag.Cat = Proudicts.Select(i => new SelectListItem(i.NameEN, i.ID.ToString()));
            var Prod = await _pro.GetById(P);
            List<IFormFile> li = new List<IFormFile>();

            //foreach(var i in Prod.productImageList)
            //{
            //    li.Add()
            //}

            //ProductModel pm = new ProductModel()
            //{
            //    NameAR = Prod.NameAR,
            //    NameEN = Prod.NameEN,
            //    Brand = Prod.Brand,
            //    Description = Prod.Description,
            //    CategoryID = Prod.CategoryID,
            //    Quantity = Prod.Quantity,
            //    UnitPrice = Prod.UnitPrice,
            //    IsDeleted = false,
            //    Discount = Prod.Discount,
            //    TotalPrice = Prod.TotalPrice,

            //};


            return View(Prod);
        }
        [HttpPost]
        public IActionResult UpdateValue(ProductDto pro)
        {
            _pro.Update(pro);

            return RedirectToAction("GetAll", "Product");
        }
        public IActionResult Delete(int prod)
        {

            _pro.Delete(prod);
            return RedirectToAction("GetAll", "Product");

        }
        [HttpGet]
        public async Task<IActionResult> GetProductByID(int id)
        {

            var c = await _img.GetByProductId(id);

            var Prod = await _pro.GetById(id); 

            //if (c != null)
            //{
              foreach (var x in c)
            {
                ViewBag.path = x.Path;
            }

            //var img = prod.productImageList.FirstOrDefault().Path;
            //if (img != null)
            //{
            //    ViewBag.path = img;
            //}
            //else
            //    ViewBag.path = "1.jpg";



            return View(Prod);
               
           // }
            
        }
        [HttpPost]
        public IActionResult GetProductByCats(int id)
        {


            return RedirectToAction("GetProductByCat", new { IId = 1 });
        }
        [HttpGet]
        //public async Task<IActionResult> GetProductByCat(int IId)
        //{

        //    var Product = await _pro.GetByCategoryId(1);
        //    //ViewBag.Cat = Proudicts.Select(i=> new SelectListItem(i.NameAR, i.ID.ToString())); ;
        //    //var Page = Proudicts.ToPagedList(pageIndex, pageSize);

        //    var Pro = await _pro.GetAll();

        //    ViewBag.Cat = Pro.Select(i => new SelectListItem(i.NameAR, i.ID.ToString()));

        //    return View(Product);
        //}
        [HttpGet]
        public async Task<IActionResult> AddProductImages()
        {
            var Pro = await _pro.GetAll();
            ViewBag.Pro = Pro.Select(i => new SelectListItem(i.NameAR, i.ID.ToString()));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProductImages(ProductIMGDTOS img)
        {

            string NewName = Guid.NewGuid().ToString() + img.Path.FileName;

            ProductImageDto prodImg = new ProductImageDto()
            {
                Path = NewName,
                ProductID = img.ProductID,
                IsDeleted = false
            };
            await _img.add(prodImg);

            FileStream fs = new FileStream(
              Path.Combine(Directory.GetCurrentDirectory(),
               "Content", "Images", "Product", NewName)
              , FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Path.CopyTo(fs);
            fs.Position = 0;


            return RedirectToAction("Index", "Home");
        }

         [HttpGet]
        public async Task<IActionResult> GetProductImages(int img)
        {
            var ProImage = await _img.GetByProductId(img);
            return View(ProImage);
        }
       [HttpGet]
      public async Task<IActionResult> DeleteProductImages(int im,int pro)
        {
             _img.Delete(im);
            var ProImage = await _img.GetByProductId(im);
           
            return RedirectToAction("GetProductImages", new {img=pro});
        }
        


    }
}
