using BLENDSEASONINGS.Models;

namespace BLENDSEASONINGS.Repos
{
    public interface IOrderRepository
    {
        public List<Order> GetAllOrders();
        Order GetOrderById(int Id);

        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        List<Order> GetOrdersByUserId(string UserId);
        List<BlendOrder> GetBlendOrderByOrderId(int orderId);

        void UpdateBlendOrder(BlendOrder blendOrder);
        void DeleteBlendOrder(int id);
        void CreateBlendOrder(BlendOrder order);
        BlendOrder GetBlendOrderById(int id);
    }
}
