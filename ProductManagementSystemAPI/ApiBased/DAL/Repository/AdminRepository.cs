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
    internal class AdminRepository:IRepository<Admin>,IAdminFeatures
    {
        PMSContext db;
        public AdminRepository(PMSContext db) { 
        this.db = db;
        }
        public Admin LogIn(string username, string password)
        {
           return db.Admins.SingleOrDefault(adm=>adm.Name==username && adm.Password==password);
        }
        public Admin AddAdmin(Admin admin)
        {
            db.Admins.Add(admin);
             db.SaveChanges();
            return admin;
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



        public bool Update(int id, Admin entity)
        {
            var existing = Find(id);
            if (existing == null) return false;

            if (!string.IsNullOrEmpty(entity.Name))
                existing.Name = entity.Name;

            if (!string.IsNullOrEmpty(entity.Password))
                existing.Password = entity.Password;

            return db.SaveChanges() > 0;
        }



    }
}
