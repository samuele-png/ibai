namespace Domain_Layer.Classes
{
    public class Stock
    {
        public Stock(Product product)
        {
            Product = product;
        }
        public Stock(Product product, int amountInStock, int suggestedAmount)
        {
            Product = product;
            AmountInStock = amountInStock;
            SuggestedAmount = suggestedAmount;
        }
        public Product Product { get; private set; }
        public int AmountInStock { get; private set; }
        public int SuggestedAmount { get; private set; }

    }
}
