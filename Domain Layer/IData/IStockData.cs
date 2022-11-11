using Domain_Layer.Classes;

namespace Domain_Layer.Interfaces
{
    public interface IStockData
    {
        List<Stock> GetStocks();
        Stock GetStock(Product product);
        void WriteStock(Stock stock);
        void DeleteStock(Stock stock);
        void UpdateStock(Stock stock);
    }
}
