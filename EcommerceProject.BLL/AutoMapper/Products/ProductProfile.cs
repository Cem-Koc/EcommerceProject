using AutoMapper;
using EcommerceProject.ENTITIES.Dtos.Products;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace EcommerceProject.BLL.AutoMapper.Products
{
	public class ProductProfile:Profile
	{
        public ProductProfile()
        {
            CreateMap<ProductDto,Product>().ReverseMap();

        }
    }
}
