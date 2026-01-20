using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class OrderRepository:IRepository<Order>,IOrderFeatures
    {
        PMSContext db;
        public OrderRepository(PMSContext db)
        {
            this.db = db;
        }

        public bool Add(Order entity)
        {
            db.Orders.Add(entity);
            return db.SaveChanges() > 0; ;
        }

       

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Order Find(int id)
        {
            return db.Orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetAll()
        {
            return db.Orders
               .Include(o => o.Items)
               .ThenInclude(i => i.Product)
               .Include(o => o.Cus)
               .ToList();
        }

        public bool Update(int id, Order entity)
        {
            var existing = Find(id);
            if (existing == null) return false;

            
            if (!string.IsNullOrEmpty(entity.Status))
                existing.Status = entity.Status;

           
            if (entity.TotalBill > 0)
                existing.TotalBill = entity.TotalBill;

            return db.SaveChanges() > 0;
        }

        public List<Order> GetOrdersWithProductsByCustomer(int Id)
        {
            return db.Orders
                .Where(o => o.CId == Id)
                .Include(o => o.Cus)
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .ToList();
        }
        public List<Order> GetPaidOrders()
        {
            return db.Orders
                .Where(o => o.Status == "Paid")
                .Include(o => o.Cus)
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .ToList();
        }

        public List<Order> GetPendingOrders()
        {
            return db.Orders
               .Where(o => o.Status == "Pending")
               .Include(o => o.Cus)
               .Include(o => o.Items)
                   .ThenInclude(i => i.Product)
               .ToList(); ;
        }
    }
}
