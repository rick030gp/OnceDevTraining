using Microsoft.EntityFrameworkCore;
using OnceDev.Training.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnceDev.Training.Infrastructure.Repository
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(NorthwindDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<OrderItem>> ListWithOrderItemItemsAsync()
        {
            return await _context.OrderItems.Include(oi => oi.Order).ToListAsync();
        }
    }
}
