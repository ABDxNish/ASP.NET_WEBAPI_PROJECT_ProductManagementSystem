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
    internal class CategoryRepository : IRepository<Category>
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

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public bool Update(Category entity)
        {
            var existing= Find(entity.Id);
            db.Entry(existing).CurrentValues.SetValues(entity);
            return db.SaveChanges() > 0;
        }
    }
}
