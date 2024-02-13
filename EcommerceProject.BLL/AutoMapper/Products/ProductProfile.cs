using AutoMapper;
using EcommerceProject.ENTITIES.Dtos.Products;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using EcommerceProject.ENTITIES.Dtos.Images;

namespace EcommerceProject.BLL.AutoMapper.Products
{
	public class ProductProfile:Profile
	{
        public ProductProfile()
        {
            CreateMap<ProductDto,Product>().ReverseMap();
            CreateMap<ProductAddDto,Product>().ReverseMap();
            CreateMap<ProductUpdateDto,Product>().ReverseMap();
            CreateMap<ProductUpdateDto,ProductDto>().ReverseMap();
            CreateMap<ImagesOperationsDto,Product>().ReverseMap();
            CreateMap<ImagesOperationsDto,ProductDto>().ReverseMap();
        }
    }
}
