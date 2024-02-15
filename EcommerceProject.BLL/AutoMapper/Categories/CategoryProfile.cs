using AutoMapper;
using EcommerceProject.ENTITIES.Dtos.Categories;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.AutoMapper.Categories
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryNameDto, Category>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CategoryListDto, Category>().ReverseMap();
            CreateMap<CategoryAddDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        }
    }
}
