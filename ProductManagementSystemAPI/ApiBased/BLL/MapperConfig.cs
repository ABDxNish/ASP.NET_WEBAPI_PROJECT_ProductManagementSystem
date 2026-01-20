using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MapperConfig
    {
        
            static MapperConfiguration cfg = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
                cfg.CreateMap<Admin, AdminDTO>().ReverseMap();
                cfg.CreateMap<Category, CategoryProductDTO>().ReverseMap();
                cfg.CreateMap<Customer, CustomerDTO>().ReverseMap();
                cfg.CreateMap<Order, OrderDTO>().ReverseMap();

            });
            public static Mapper GetMapper()
            {
                return new Mapper(cfg);
            }
        }
    
}
