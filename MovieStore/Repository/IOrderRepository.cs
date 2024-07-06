using System.Linq;
using MovieStore.Models;

namespace MovieStore.Repository
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        Order SaveOrder(Order order);

        Order Remove(int orderId);
        Order UpdateOrder(Order order);
    }
}
