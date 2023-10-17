using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.DTO.Category;
using DataLayer.DTO.Product;
using DataLayer.DTO.ProductFeature;
using DataLayer.DTO.Slider;
using DataLayer.DTO.SubProduct;
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
            CreateMap<Product, ModifyProductDTO>().ReverseMap();
            CreateMap<ModifyProductDTO, Product>().ReverseMap();
            CreateMap<ProductInfo,ModifyProductFeatureDTO>().ReverseMap();
            CreateMap<ModifyProductFeatureDTO, ProductInfo>().ReverseMap();
            CreateMap<SubProduct, ShowSubproductDTO>().ReverseMap();
            CreateMap<ShowSubproductDTO, SubProduct>().ReverseMap();
            CreateMap<SubProduct, EditSubProductDTO>().ReverseMap();
            CreateMap<EditSubProductDTO, SubProduct>().ReverseMap();
            CreateMap<Slider, EditSliderDTO>().ReverseMap();
            CreateMap<EditSliderDTO, Slider>().ReverseMap();
        }
    }
}
