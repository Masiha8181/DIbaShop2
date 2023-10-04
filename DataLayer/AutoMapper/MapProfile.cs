using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.DTO.Category;
using DataLayer.DTO.User;
using DataLayer.Entities;

namespace DataLayer.AutoMapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserListDTO>().ReverseMap();
            CreateMap<User, EditUserDTO>().ReverseMap();
            CreateMap<CategoryProduct, ModifyCategoryProductDTO>().ReverseMap();
            CreateMap<ModifyCategoryProductDTO, CategoryProduct>().ReverseMap();

        }
    }
}
