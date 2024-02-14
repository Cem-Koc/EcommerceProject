using AutoMapper;
using EcommerceProject.ENTITIES.Dtos.Images;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.AutoMapper.ImageDetails
{
	public class ImageDetailProfile:Profile
	{
        public ImageDetailProfile()
        {
            CreateMap<ImageDetailDto,ImageDetail>().ReverseMap();
        }
    }
}
