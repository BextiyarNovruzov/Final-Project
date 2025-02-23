using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.Cart;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Imlements
{
    public class OrderService(IOrderRepository orderRepository, IProductRepository productRepository) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly StripeClient _stripeClient;

        //public async Task<bool> CreateOrderAsync(OrderDetail order)
        //{
        
        //    return await _orderRepository.CreateOrderAsync(order);
        //}
        //public async Task<bool> ProcessPaymentAsync(string token, decimal amount)
        //{
        //    var options = new ChargeCreateOptions
        //    {
        //        Amount = (long)(amount * 100), // Amount in cents
        //        Currency = "usd",
        //        Source = token,
        //        Description = "Payment for Order",
        //    };

        //    var service = new ChargeService(_stripeClient);
        //    var charge = await service.CreateAsync(options);

        //    return charge.Status == "succeeded";
        //}
    }   

}
