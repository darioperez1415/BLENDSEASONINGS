using BLENDSEASONINGS.Models;

namespace BLENDSEASONINGS.Repos
{
    public interface IOrderRepository
    {
        public List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void CreateOrder(Order newOrder);
        void CreateOrderTransaction(OrderTransaction transaction);
        void DeleteOrderTrasaction(int id);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        List<Order> GetOrdersByUserId(string UserId);
    }
}
