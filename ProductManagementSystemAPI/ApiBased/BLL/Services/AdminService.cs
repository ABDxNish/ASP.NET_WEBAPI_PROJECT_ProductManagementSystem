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
    public class AdminService
    {
        DataAccessFactory factory;
        public AdminService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public List<AdminDTO> GetAll()
        {
            var data = factory.AdminData().GetAll();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<AdminDTO>>(data);
            return ret;
        }
        public AdminDTO Find(int id)
        {
            return MapperConfig.GetMapper().Map<AdminDTO>(factory.AdminData().Find(id));

        }
        public bool Add(AdminDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Admin>(c);
            return factory.AdminData().Add(data);
        }
        public bool Update(AdminDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Admin>(c);
            return factory.AdminData().Update(data);
        }
        public bool Delete(int id)
        {
            return factory.AdminData().Delete(id);
        }
    }
}
