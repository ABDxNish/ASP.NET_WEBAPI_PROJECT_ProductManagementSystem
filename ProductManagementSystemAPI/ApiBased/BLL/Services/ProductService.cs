using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        DataAccessFactory factory;
        public ProductService(DataAccessFactory factory) {
        this.factory = factory;
        }
        public List<ProductDTO> GetAll()
        {
            var data = factory.ProductData().GetAll();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<ProductDTO>>(data);
            return ret;
        }
        public ProductDTO Find(int id)
        {
            return MapperConfig.GetMapper().Map<ProductDTO>(factory.ProductData().Find(id));

        }
        public bool Add(ProductDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Product>(c);
            return factory.ProductData().Add(data);
        }
        public bool Update(int id, ProductDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Product>(c);
            return factory.ProductData().Update(id,data);
        }
        public bool Delete(int id)
        {
            return factory.ProductData().Delete(id);
        }
    }
}
