using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        PMSContext db;
        public DataAccessFactory(PMSContext db) {
        this.db = db;
        }
        public IRepository<Category> CategoryData()
        {
            return new CategoryRepository(db);
        }
        public IRepository<Product> ProductData()
        {
            return new ProductRepository(db); 
        }
        public  IRepository<Admin>AdminData() 
        {
            return new AdminRepository(db);
        }
        public IAdminFeatures AdminDataL()
        {
            return new AdminRepository(db);
        }
        public ICategoryFeatures CategoryFeatures()
        {
            return new CategoryRepository(db);
        }
        public IRepository<Order> OrderData()
        {
            return new OrderRepository(db);
        }
        public IRepository<Customer> CustomerData()
        {
            return new CustomerRepository(db);
        }

        public ICustomerFeatures CustomerFeatures() {
            return new CustomerRepository(db);
        }
        public IOrderFeatures OrderFeatures()
        {
            return new OrderRepository(db);
        }
    }
}
