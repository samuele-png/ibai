namespace Domain_Layer.Classes
{
    public class Order
    {
        public Order(int orderId)
        {
            OrderId = orderId;
        }
        public Order(int orderId, User user, List<Product> products)
        {
            OrderId = orderId;
            User = user;
            Products = products;
        }

        public int OrderId { get; set; }
        public User User { get; set; }
        public List<Product>? Products { get; set; }
    }
}
