using BLL.DTOs;
using DAL;
using DAL.EF.Models;
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
            
            var customer = factory.CustomerData().Find(dto.CustomerId);
            if (customer == null)
            {
                throw new Exception("Invalid Customer");
            }

            decimal total = 0;
            List<OrderItem> items = new List<OrderItem>();

            foreach (var pid in dto.PId)
            {
                var product = factory.ProductData().Find(pid);

                if (product == null)
                {
                    throw new Exception("Invalid Product ID: " + pid);
                }

                total += product.Price;

                items.Add(new OrderItem
                {
                    ProductId = pid
                });
            }

            Order order = new Order
            {
                CId = dto.CustomerId,
                OrderDate = DateTime.Now,
                Status = "Pending",
                TotalBill = total,
                Items = items
            };

            factory.OrderData().Add(order);

            return new OrderDTO
            {
                Id = order.Id,
                TotalBill = order.TotalBill,
                Status = order.Status
            };
        }
        public List<CusProductOrderDTO> GetOrdersByCustomer(int customerId)
        {
            var orders = factory.OrderFeatures()
                .GetOrdersWithProductsByCustomer(customerId);

            List<CusProductOrderDTO> result = new();

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
                        CId = i.Product.CId
                    });
                }

                result.Add(dto);
            }

            return result;
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
