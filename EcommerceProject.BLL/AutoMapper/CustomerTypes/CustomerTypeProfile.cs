using AutoMapper;
using EcommerceProject.ENTITIES.Dtos.CustomerTypes;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.AutoMapper.CustomerTypes
{
    public class CustomerTypeProfile:Profile
    {
        public CustomerTypeProfile()
        {
            CreateMap<CustomerTypeDto, CustomerType>().ReverseMap();
        }
    }
}
