namespace DTOs
{
    public class ProductImageDto
    {
        public int ID { get; set; }
        public string Path { get; set; }
        public int ProductID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
