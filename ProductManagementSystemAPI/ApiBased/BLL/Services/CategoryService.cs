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
    public class CategoryService
    {
        DataAccessFactory factory;
        public CategoryService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public List<CategoryDTO> GetAll()
        {
            var data = factory.CategoryData().GetAll();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<CategoryDTO>>(data);
            return ret;
        }
        public CategoryDTO Find(int id)
        {
            return MapperConfig.GetMapper().Map<CategoryDTO>(factory.CategoryData().Find(id));

        }
        public bool Add(CategoryDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Category>(c);
            return factory.CategoryData().Add(data);
        }
        public bool Update(int id,CategoryDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Category>(c);
            return factory.CategoryData().Update(id,data);
        }
        public bool Delete(int id)
        {
            return factory.CategoryData().Delete(id);
        }
    
    public List<CategoryProductDTO> FindAllWithProducts() {
            var data = factory.CategoryFeatures().FindAllWithProducts();
            var mapper = MapperConfig.GetMapper().Map<List<CategoryProductDTO>>(data);
            return mapper;


        }
        public CategoryDTO FindByName(string name)
        {
            return MapperConfig.GetMapper()
               .Map<CategoryDTO>(factory.CategoryFeatures().FindByName(name));
        }
        public CategoryProductDTO HighestProdsucts()
        {
            return MapperConfig.GetMapper()
               .Map<CategoryProductDTO>(factory.CategoryFeatures().HighestProducts());
        }
        public CategoryProductDTO FindWithProducts(int id)
        {
            return MapperConfig.GetMapper()
               .Map<CategoryProductDTO>(factory.CategoryFeatures().FindWithProducts(id));

        }
    }
}
