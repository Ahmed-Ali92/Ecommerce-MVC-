using System.ComponentModel.DataAnnotations;

namespace ITI.Ecommerce.Presenation
{
    public class ProductModel
    {
        public int ID { get; set; }
        [Display(Name = "Name AraBic")]
        [Required(ErrorMessage = "حrل الاسم مطلوب")]
        [MaxLength(500, ErrorMessage = "لا يزيد عن 500")]
        [MinLength(4, ErrorMessage = "Must Be More Than Or Equals 4 Chars.")]
        public string NameAR { get; set; }
        [Display(Name = "Name English")]
        [Required(ErrorMessage = "حثل الاسم مطلوب")]
        [MaxLength(500, ErrorMessage = "لا يزيد عن 500")]
        [MinLength(4, ErrorMessage = "Must Be More Than Or Equals 4 Chars.")]
        public string NameEN { get; set; }
        [Display(Name = " Brand")]
        [Required(ErrorMessage = "حثل البرند مطلوب")]
        [MaxLength(500, ErrorMessage = "لا يزيد عن 500")]
        public string Brand { get; set; }
        [Display(Name = " Description")]
        [Required(ErrorMessage = "حثل الوصف مطلوب")]
        [MaxLength(500, ErrorMessage = "لا يزيد عن 500")]

        public string Description { get; set; }

        public int CategoryID { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]

        public int Quantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public float UnitPrice { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid  Number")]
        public float Discount { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public float TotalPrice { get; set; }
        public bool IsDeleted { get; set; }
        /// public ICollection<Microsoft.AspNetCore.Http.IFormFile> Images { get; set; }
        public List<IFormFile> Images { get; set; }

    }
}
