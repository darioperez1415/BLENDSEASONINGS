using BLENDSEASONINGS.Models;

namespace BLENDSEASONINGS.Repos
{
    public interface IOrderRepository
    {
        public List<Order> GetAllOrders();
    }
}
