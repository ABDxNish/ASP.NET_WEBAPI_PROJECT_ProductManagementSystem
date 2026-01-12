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
        public bool Update(CategoryDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Category>(c);
            return factory.CategoryData().Update(data);
        }
        public bool Delete(int id)
        {
            return factory.CategoryData().Delete(id);
        }
    }
}
