using Domain_Layer.Classes;
using Domain_Layer.Interfaces;
namespace Domain_Layer.ClassManagers
{
    public class StockManager
    {//take interface and inject it into the constructor of the manager
        IStockData _StockData;
        public StockManager(IStockData stockData)
        {
            _StockData = stockData;
        }
        public void WriteStock(Stock stock)
        {
            _StockData.WriteStock(stock);
        }
        public List<Stock> GetStocks()
        {
            return _StockData.GetStocks();
        }
        public Stock GetStock(Product product)
        {
            return _StockData.GetStock(product);
        }
        public void DeleteStock(Stock stock)
        {
            _StockData.DeleteStock(stock);
        }
        public void UpdateStock(Stock stock)
        {
            _StockData.UpdateStock(stock);
        }
    }
}
