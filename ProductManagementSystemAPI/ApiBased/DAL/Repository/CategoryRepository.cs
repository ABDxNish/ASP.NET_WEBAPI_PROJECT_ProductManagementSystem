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
    internal class CategoryRepository : IRepository<Category>,ICategoryFeatures
    {
        PMSContext db;
        public CategoryRepository(PMSContext db)
        {
            this.db = db;
        }
        public bool Add(Category entity)
        {
            db.Categories.Add(entity);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var existing=Find(id);
            db.Categories.Remove(existing);
            return db.SaveChanges()>0;
        }

        public Category Find(int id)
        {
            return db.Categories.Find(id);

        }

        public Category FindByName(string name)
        {
            var data=(from c in db.Categories
                      where c.Name.Contains(name)
                      select c).SingleOrDefault();
            return data;
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public List<Category> FindAllWithProducts()
        {
            return db.Categories.Include(c => c.Products).ToList();

        }

        public Category HighestProducts()
        {
            var data=(from c in db.Categories.Include(c=>c.Products)
                      orderby c.Products.Count() descending
                      select c).FirstOrDefault();
            return data;
        }

        public bool Update(int id, Category entity)
        {
            var existing = Find(id);
            if (existing == null) return false;

            if (!string.IsNullOrEmpty(entity.Name))
                existing.Name = entity.Name;

            return db.SaveChanges() > 0;
        }


        public Category FindWithProducts(int id)
        {
            var data=( from c in db.Categories.Include(ct => ct.Products)
                      where c.Id == id
                      select c).SingleOrDefault();
            return data;
        }

        
    }
}
