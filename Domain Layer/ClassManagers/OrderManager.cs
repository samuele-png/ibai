using Domain_Layer.Classes;

namespace Domain_Layer.Interfaces;

public class OrderManager
{ //take interface and inject it into the constructor of the manager


    IOrderData _OrderData;
    public OrderManager(IOrderData orderData)
    {
        _OrderData = orderData;
    }
    public void WriteOrder(Order order)
    {
        _OrderData.WriteOrder(order);
    }
    public List<Order> GetOrders()
    {
        return _OrderData.GetOrders();
    }
    public Order GetOrder(Order order)
    {
        return _OrderData.GetOrder(order);
    }
    public void DeleteProduct(Order order)
    {
        _OrderData.DeleteOrder(order);
    }
    public void UpdateSProduct(Order order)
    {
        _OrderData.UpdateOrder(order);
    }

}
