using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderFeatures
    {
        List<Order> GetOrdersWithProductsByCustomer(int Id);

        List<Order> GetPaidOrders();
        List<Order> GetPendingOrders();
    }
}
