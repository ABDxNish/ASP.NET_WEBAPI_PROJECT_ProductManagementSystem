using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;
using System.Security.Cryptography;
using System.Text;


namespace BLL.Services
{
    public class AdminService
    {
        DataAccessFactory factory;
        public AdminService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public bool LogIn(AdminDTO adm)
        {

            string hashedPassword = CreateMD5(adm.Password);
            return factory.AdminDataL().LogIn(adm.Name, hashedPassword) != null;
        }
        public static string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
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
            data.Password = CreateMD5(data.Password);
            var savedAdmin= factory.AdminDataL().AddAdmin(data);
            if (savedAdmin != null)
            {
                string body =
                    "A new admin is added\n" +
                    "Id: " + savedAdmin.Id + "\n" +
                    "Name: " + savedAdmin.Name;

                MailerService.Send(
                    "pm5612356@gmail.com",
                    "New Admin Added",
                    body
                );

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(int id,AdminDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Admin>(c);
            return factory.AdminData().Update(id,data);
        }
        public bool Delete(int id)
        {
            return factory.AdminData().Delete(id);
        }
    }
}
