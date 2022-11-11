using Domain_Layer.Classes;

namespace Domain_Layer.Interfaces
{
    public interface IOrderData
    {
        List<Order> GetOrders();
        Order GetOrder(Order order);
        void WriteOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
