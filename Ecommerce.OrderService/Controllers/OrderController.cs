using Ecommerce.Model;
using Ecommerce.OrderService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(OrderDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<List<OrderModel>> GetOrders()
        {
            return await dbContext.Orders.ToListAsync();
        }

        [HttpPost]
        public async Task<OrderModel> Createorder(OrderModel order)
        {
            order.OrderDate = DateTime.Now;
            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync(); 
            return order;
        }
    }

}
