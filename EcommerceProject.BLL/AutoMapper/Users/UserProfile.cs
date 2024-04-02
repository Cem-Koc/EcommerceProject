using AutoMapper;
using EcommerceProject.ENTITIES.Dtos.Users;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.AutoMapper.Users
{
	public class UserProfile:Profile
	{
        public UserProfile()
        {
			CreateMap<AppUser, UserListDto>().ForMember(appUser=>appUser.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
			CreateMap<AppUser, UserUpdateDto>().ForMember(appUser=>appUser.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
			CreateMap<AppUser, UserAddDto>().ReverseMap();
			CreateMap<AppUser, UserProfileDto>().ReverseMap();
			CreateMap<AppUser, UserRegisterDto>().ReverseMap();
			CreateMap<UserAddDto, UserRegisterDto>().ReverseMap();
			CreateMap<AppUser, MyProfileUpdateDto>().ForMember(appUser => appUser.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
		}
    }
}