namespace DTOs
{
    public class OrderDto
    {
        public int ID { get; set; }
        public string CustomerId { get; set; }
        public int PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; }
        public int ShoppingCartId { get; set; }


    }
}
