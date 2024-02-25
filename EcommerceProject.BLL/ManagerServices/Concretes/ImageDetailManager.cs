using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.Images;
using EcommerceProject.ENTITIES.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
	public class ImageDetailManager:IImageDetailManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        public ImageDetailManager(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext.User;
        }

        public async Task<List<ImageDetailDto>> GetAllImageDetails()
        {
            var imageDetails = await _unitOfWork.GetRepository<ImageDetail>().GetAllAsync();
            var map = _mapper.Map<List<ImageDetailDto>>(imageDetails);
            return map;
        }

        public List<ImageDetailDto> GetImageDetailsByProductID(int productID)
		{
			var imageDetails = _unitOfWork.GetRepository<ImageDetail>().Where(x=>x.ProductID==productID).ToList();
			var map = _mapper.Map<List<ImageDetailDto>>(imageDetails);
			return map;
		}

		public async Task<bool> AssignmentImageDetailsByProductID(int productSourceID, int productDestinationID)
		{
            var imageDetailsSource = _unitOfWork.GetRepository<ImageDetail>().Where(x => x.ProductID == productSourceID).ToList();
            var imageDetailsDestination = _unitOfWork.GetRepository<ImageDetail>().Where(x => x.ProductID == productDestinationID).ToList();

            if (imageDetailsSource.Count == 0 || imageDetailsDestination.Count > 0)
            {
				return false;
            }

            foreach (var item in imageDetailsSource)
            {
                ImageDetail imageDetail = new ImageDetail
                {
                    ImageID = item.ImageID,
                    ProductID = productDestinationID,
                    CreatedBy = _user.GetLoggedInUserEmail(),
                    SortImage = item.SortImage
                };

                await _unitOfWork.GetRepository<ImageDetail>().AddAsync(imageDetail);
                await _unitOfWork.SaveAsync();
            }
            return true;
        }

    }
}
