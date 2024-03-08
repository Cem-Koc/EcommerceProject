using AutoMapper;
using EcommerceProject.ENTITIES.Dtos.Orders;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.AutoMapper.Orders
{
	public class OrderProfile : Profile
	{
        public OrderProfile()
        {
            CreateMap<OrderViewDto , Order>().ReverseMap();
            CreateMap<OrderAddDto , Order>().ReverseMap();
        }
    }
}
