using AutoMapper;
using EcommerceProject.ENTITIES.Dtos.ProductColors;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.AutoMapper.ProductColors
{
    public class ProductColorProfile:Profile
    {
        public ProductColorProfile()
        {
            CreateMap<ProductColorDto,ProductColor>().ReverseMap();
        }
    }
}
