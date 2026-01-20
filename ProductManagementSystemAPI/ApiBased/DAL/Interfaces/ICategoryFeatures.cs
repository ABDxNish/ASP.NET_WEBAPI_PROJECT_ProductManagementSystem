using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoryFeatures
    {
        List<Category> FindAllWithProducts();
        Category FindByName(string name);
        Category HighestProducts();
        Category FindWithProducts(int id);
    }
}
