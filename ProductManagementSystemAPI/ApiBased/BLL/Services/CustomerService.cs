using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService
    {
        DataAccessFactory factory;
        public CustomerService(DataAccessFactory factory)
        {
            this.factory = factory;
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

        public bool LogIn(CustomerDTO cus)
        {
            string hashedPassword = CreateMD5(cus.Password);
            return factory.CustomerFeatures().LogIn(cus.UserName, hashedPassword) != null;
        }
        public bool Add(CustomerDTO cus)

        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Customer>(cus);
            data.Password = CreateMD5(data.Password);
            return factory.CustomerData().Add(data);
        }
    }
}
