namespace DTOs
{
    public class CategoryDto
    {
        public int ID { set; get; }
        public string NameAR { set; get; }
        public string NameEN { set; get; }
        public bool IsDeleted { set; get; }

        public ICollection<ProductDto> ProductList { get; set; }
    }
}
