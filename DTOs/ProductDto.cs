namespace DTOs
{
    public class ProductDto
    {
        public int ID { get; set; }
        public string NameAR { get; set; }
        public string NameEN { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float Discount { get; set; }
        public float TotalPrice { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ProductImageDto> productImageList { get; set; }
        public ICollection<ShoppingCartDto> ShoppingCartList { get; set; }
    }
}
