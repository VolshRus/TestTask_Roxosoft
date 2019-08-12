using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using WebApp.Models;

namespace WebApp.Interfaces
{
    /// <summary>
    /// BLL to work with Order model
    /// </summary>
    public interface IOrdersService
    {
        /// <summary>
        /// Returns a part of orders list, need for lazy loading
        /// </summary>
        /// <param name="start">Ordinal number (from zero) of first order in sequence</param>
        /// <param name="amount">Amount of orders in sequence</param>
        /// <param name="cancellationToken"></param>
        Task<ICollection<Order>> GetOrdersAsync(int start, int amount, CancellationToken cancellationToken);

        /// <summary>
        /// Returns an products info within order
        /// </summary>
        /// <param name="orderId">Order id</param>
        /// <param name="cancellationToken"></param>
        Task<Order> GetOrderDetailedAsync(int orderId, CancellationToken cancellationToken);
    }
}
