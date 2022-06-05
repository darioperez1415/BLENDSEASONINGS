using BLENDSEASONINGS.Models;

namespace BLENDSEASONINGS.Repos
{
    public interface IOrderRepository
    {
        public List<Order> GetAllOrders();
        Order GetOrderById(int Id);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
    }
}
