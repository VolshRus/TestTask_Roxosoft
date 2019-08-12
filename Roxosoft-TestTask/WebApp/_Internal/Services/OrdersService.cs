using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using WebApp._Internal.Repositories;
using WebApp.Interfaces;
using WebApp.Exceptions;
using WebApp.Models;

namespace WebApp.Services
{
    internal class OrdersService:IOrdersService
    {
        public OrdersService(OrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        /// <inheritdoc />
        public async Task<ICollection<Order>> GetOrdersAsync(int start, int amount, CancellationToken cancellationToken)
        {
            var list = await _ordersRepository.GetOrdersListAsync(start, amount, cancellationToken);

            return list;
        }

        /// <inheritdoc />
        public async Task<Order> GetOrderDetailedAsync(int orderId, CancellationToken cancellationToken)
        {
            var maybeOrder = await _ordersRepository.GetOrderDetailAsync(orderId, cancellationToken);

            var order = maybeOrder.Case(
                some: el => el,
                none: () => throw new EmptyQueryResultException()
            );

            return order;
        }

        private readonly OrdersRepository _ordersRepository;
    }
}
