using AutoMapper;
using EcommerceProject.ENTITIES.Dtos.ProductSizes;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.AutoMapper.ProductSizes
{
    public class ProductSizeProfile:Profile
    {
        public ProductSizeProfile()
        {
            CreateMap<ProductSizeDto, ProductSize>().ReverseMap();
            CreateMap<ProductSizeAddDto, ProductSize>().ReverseMap();
            CreateMap<ProductSizeUpdateDto, ProductSize>().ReverseMap();
        }
    }
}
