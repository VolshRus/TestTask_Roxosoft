using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using WebApp._Internal.Entities;
using WebApp._Internal.Helpers;
using WebApp.Models;

namespace WebApp._Internal.Repositories
{
    internal class OrdersRepository:DbContext
    {
        public OrdersRepository(IMapper mapper, DbContextOptions options) : base(options) => _mapper = mapper;

        public async Task<ICollection<Order>> GetOrdersListAsync(int start, int amount, CancellationToken cancellationToken)
        {
            var result = await _orders.OrderBy(o=>o.Created)
                                      .Skip(start)
                                      .Take(amount)
                                      .AsNoTracking()
                                      .ToListAsync(cancellationToken);

            var orders = _mapper.Map<ICollection<Order>>(result);

            return orders;
        }

        public async Task<Maybe<Order>> GetOrderDetailAsync(int orderId, CancellationToken cancellationToken)
        {
            var result = await _orders.Where(o=>o.Id == orderId)
                                      .Include(op=>op.OrderProducts)
                                          .ThenInclude(p=>p.Product)
                                      .AsNoTracking()
                                      .ToListAsync(cancellationToken);

            if (result.Any())
            {
                var order = _mapper.Map<Order>(result.Single());
                return Maybe<Order>.Some(order);
            }
            else
                return Maybe<Order>.None;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProductEntity>()
                .HasOne(p => p.Product)
                .WithMany();

            modelBuilder.Entity<OrderProductEntity>()
                .HasOne(p => p.Order)
                .WithMany();

            // TODO: I wants to move this into Tests project, but allotted time have runs out. So its still here
            modelBuilder.Entity<OrderEntity>().HasData(
            new
            {
                Id = 1,
                Created = new DateTimeOffset(2019,7,10,13,14,14,100, new TimeSpan(3,0,0)),
                Status = OrderStatusEntity.Complete
            },
            new
            {
                Id = 2,
                Created = new DateTimeOffset(2019, 9, 19, 19, 19, 19, 0, new TimeSpan(5, 0, 0)),
                Status = OrderStatusEntity.InProgress
            }
            );
            modelBuilder.Entity<ProductEntity>().HasData(
            new
            {
                Id = 1,
                Name = "TestProduct1",
                Price = 12.2,
                Quantity = 10
            },
            new
            {
                Id = 2,
                Name = "TestProduct2",
                Price = 122.0,
                Quantity = 10
            },
            new
            {
                Id = 3,
                Name = "TestProduct3",
                Price = 10.0,
                Quantity = 1000
            }
            );
            modelBuilder.Entity<OrderProductEntity>().HasData(
            new
            {
                Id = Guid.NewGuid(),
                OrderId = 1,
                ProductId = 1,
            },
            new
            {
                Id = Guid.NewGuid(),
                OrderId = 1,
                ProductId = 2,
            },
            new
            {
                Id = Guid.NewGuid(),
                OrderId = 2,
                ProductId = 3,
            }
            );

            base.OnModelCreating(modelBuilder);
        }

        private DbSet<OrderEntity> _orders { get; set; }
        private IMapper _mapper { get; set; }
    }
}
