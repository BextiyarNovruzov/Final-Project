using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Gymon.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Repositories
{
    public class OrderRepository(GymonDbContext context) : GenericRepository<OrderDetail>(context), IOrderRepository
    {
        //public async Task<List<OrderDetail>> GetOrdersByUserIdAsync(int userId)
        //{
        //    return await Table.Where(o => o.UserId == userId).Include(o => o.OrderNote).ToListAsync();
        //}
        //public async Task<bool> CreateOrderAsync(OrderDetail order)
        //{
        ////    await context..AddAsync(order);
        ////    await context.SaveChangesAsync();
        //    return true;
        //}

    }

}
