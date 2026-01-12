using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class ProductRepository : IRepository<Product>
    {
        PMSContext db;
        public ProductRepository(PMSContext db)
        {
            this.db = db;
        }

        public bool Add(Product entity)
        {
            db.Products.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var existing= Find(id);
            db.Products.Remove(existing);
            return db.SaveChanges() > 0;
        }

        public Product Find(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> GetAll()
        {
           return db.Products.ToList();
        }

        public bool Update(Product entity)
        {
            var existing = Find(entity.Id);
            db.Entry(existing).CurrentValues.SetValues(entity);
            return db.SaveChanges() > 0;
        }
    }
}
