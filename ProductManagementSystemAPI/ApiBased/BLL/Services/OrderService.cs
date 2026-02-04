using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService
    {
        DataAccessFactory factory;
        public OrderService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public OrderDTO PlaceOrder(CustOrderDTO dto)
        {
            var existing = factory.CustomerData().Find(dto.CustomerId);
            if (existing == null)
            {
                throw new Exception("Customer Not found");

            }
            decimal total = 0;
            List<OrderItem> items = new List<OrderItem>();
            foreach (var pid in dto.PId)
            {
                var existingProduct = factory.ProductData().Find(pid);
                if (existingProduct == null)
                {
                    throw new Exception($"{pid} does not exist.");
                }
                total += existingProduct.Price;
                items.Add(new OrderItem
                {
                    ProductId = pid
                });
            }
            Order orders = new Order
            {
                CId = dto.CustomerId,
                TotalBill = total,
                OrderDate = DateTime.Now,
                Status = "Pending",
                Items = items
            };
            factory.OrderData().Add(orders);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<OrderDTO>(orders);
        }
        public List<CusProductOrderDTO> GetOrdersByCustomer(int cId)
        {
            var orders=factory.OrderFeatures().GetOrdersWithProductsByCustomer(cId);
            List<CusProductOrderDTO> value = new();
            foreach (var o in orders)
            {
                CusProductOrderDTO dto = new CusProductOrderDTO
                {
                    OrderId = o.Id,
                    CustomerName = o.Cus.UserName,
                    TotalBill = o.TotalBill,
                    Items = new List<ProductDTO>()
                };
                foreach (var i in o.Items)
                {
                    dto.Items.Add(new ProductDTO
                    {
                        Name = i.Product.Name,
                        Price = i.Product.Price,
                        Quantity = 1,
                        CId = i.ProductId
                    });
                }
                value.Add(dto);
            }

                return value;
        }

        public OrderDTO PayOrder(int orderId)
        {
            var order = factory.OrderData().Find(orderId);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            if (order.Status == "Paid")
            {
                throw new Exception("Order already paid");
            }

            order.Status = "Paid";
            factory.OrderData().Update(order.Id,order);

            var mapper = MapperConfig.GetMapper();
            return mapper.Map<OrderDTO>(order);
        }
        public List<OrderDTO> GetPaidOrdersForAdmin()
        {
            
            var orders = factory.OrderFeatures().GetPaidOrders();

            var mapper = MapperConfig.GetMapper();

            return mapper.Map<List<OrderDTO>>(orders);
        }
        public List<OrderDTO> GetPendingOrdersForAdmin()
        {
            
            var orders = factory.OrderFeatures().GetPendingOrders();

            var mapper = MapperConfig.GetMapper();

            return mapper.Map<List<OrderDTO>>(orders);
        }



    }
}
