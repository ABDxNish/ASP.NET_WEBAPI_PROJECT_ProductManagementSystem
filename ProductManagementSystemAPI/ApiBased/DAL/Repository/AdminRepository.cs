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
    internal class AdminRepository:IRepository<Admin>
    {
        PMSContext db;
        public AdminRepository(PMSContext db) { 
        this.db = db;
        }

        public bool Add(Admin entity)
        {
            db.Admins.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
           var existing=Find(id);
            db.Admins.Remove(existing);
            return db.SaveChanges()>0;
        }

        public Admin Find(int id)
        {
            return db.Admins.Find(id);
        }

        public List<Admin> GetAll()
        {
            return db.Admins.ToList();
        }

        public bool Update(Admin entity)
        {
            var existing= Find(entity.Id);
            db.Entry(existing).CurrentValues.SetValues(entity);
            return db.SaveChanges() > 0;
        }
    }
}
