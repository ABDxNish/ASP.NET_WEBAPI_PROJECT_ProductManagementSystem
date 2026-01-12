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
        public IRepository<Product> ProductData() { return new ProductRepository(db); }
        public  IRepository<Admin>AdminData() { return new AdminRepository(db); } 
    }
}
