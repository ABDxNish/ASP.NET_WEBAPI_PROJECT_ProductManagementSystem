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
    internal class CustomerRepository:IRepository<Customer>,ICustomerFeatures
    {
        PMSContext db;
        public CustomerRepository(PMSContext db)
        {
            this.db = db;
        }
        public Customer LogIn(string username, string password)
        {
            return db.Customers.SingleOrDefault(adm => adm.UserName == username && adm.Password == password);
        }
        public Customer AddCustomer(Customer Customer)
        {
            db.Customers.Add(Customer);
            db.SaveChanges();
            return Customer;
        }

        public bool Add(Customer entity)
        {
            db.Customers.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var existing = Find(id);
            db.Customers.Remove(existing);
            return db.SaveChanges() > 0;
        }

        public Customer Find(int id)
        {
            return db.Customers.Find(id);
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }



        public bool Update(int id, Customer entity)
        {
            var existing = Find(id);
            if (existing == null) return false;

            if (!string.IsNullOrEmpty(entity.UserName))
                existing.UserName = entity.UserName;

            if (!string.IsNullOrEmpty(entity.Password))
                existing.Password = entity.Password;

            return db.SaveChanges() > 0;
        }

    }
}
