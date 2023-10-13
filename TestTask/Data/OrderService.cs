using Microsoft.EntityFrameworkCore;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Data
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context) => _context = context;

        public async Task<Order> GetOrder() => await _context.Orders.OrderByDescending(x => x.Price).FirstOrDefaultAsync();

        public async Task<List<Order>> GetOrders() 
            => await _context.Orders
                .Where(x => x.Quantity > 10)
                .ToListAsync();
    }
}
