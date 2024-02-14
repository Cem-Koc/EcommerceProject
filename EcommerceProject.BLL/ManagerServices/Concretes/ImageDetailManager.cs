using AutoMapper;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.Images;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
	public class ImageDetailManager:IImageDetailManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public ImageDetailManager(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public List<ImageDetailDto> GetImageDetailsByProductID(int productID)
		{
			var imageDetails = _unitOfWork.GetRepository<ImageDetail>().Where(x=>x.ProductID==productID).ToList();
			var map = _mapper.Map<List<ImageDetailDto>>(imageDetails);
			return map;
		}
	}
}
