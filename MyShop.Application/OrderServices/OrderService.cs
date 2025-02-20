using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using MyShop.Application.Dto.OrderDetail;

using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyShop.Application.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderInterface _OrderRepository;
        private readonly IOrderDetailRepository _OrderDetailRepository;
        public OrderService(IOrderInterface orderInterface, IOrderDetailRepository orderDetailRepository)
        {
            _OrderDetailRepository = orderDetailRepository;
            _OrderRepository = orderInterface;
        }


        public async Task CreateOrder(ODetailDto oDetailDtos, int UserId)
        {
            var currentOrder = await _OrderRepository.CheckExitsOrders(UserId);
            if (currentOrder == null)
            {
                var order = new Order()
                {
                    UserId = UserId,
                    IsPay = false,
                    Deatils = new List<OrderDetail>()


                };
                var NOrder = await _OrderRepository.CreateOrder(order);


                var orderdetial = new OrderDetail
                {
                    orderId = order.Id,
                    ProductId = oDetailDtos.ProductId,
                    Price = oDetailDtos.Price,
                    Quantity = oDetailDtos.Quantity,

                };



                var ordersdetial = await _OrderDetailRepository.CreateOrderDetail(orderdetial);
                order.TotalAmount = order.OrderPriceTotal();
                await _OrderRepository.UpdateOrder(order);

            }
            else
            {
                OrderDetail items = currentOrder.Deatils.FirstOrDefault(d => d.ProductId == oDetailDtos.ProductId);
                if (items != null)
                {
                    items.Quantity += oDetailDtos.Quantity;
                  
                    await _OrderDetailRepository.UpdateOrderDetail(items);
                    currentOrder.TotalAmount = currentOrder.OrderPriceTotal();
                    

                }
                else
                {
                    var ordedetails = new OrderDetail
                    {
                        orderId = currentOrder.Id,
                        ProductId = oDetailDtos.ProductId,
                        Price = oDetailDtos.Price,
                        Quantity = oDetailDtos.Quantity,

                    };
                  
                    await _OrderDetailRepository.UpdateOrderDetail(ordedetails);
                    currentOrder.TotalAmount = currentOrder.OrderPriceTotal();
                   
                }
                 await _OrderRepository.UpdateOrder(currentOrder);
               
            }

        }
    }
}
