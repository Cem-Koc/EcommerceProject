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
	public class ImageManager:IImageManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ImageManager(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public ImageDto GetByImageID(int imageID)
		{
			var image = _unitOfWork.GetRepository<Image>().Where(x=>x.ID == imageID).First();
			var map = _mapper.Map<ImageDto>(image);
			return map;
		}
		public List<ImageDto> GetImageByImageDetails(List<ImageDetailDto> imageDetailDtos)
		{
			List<ImageDto> imageList = new List<ImageDto>();
            foreach (var imageDetail in imageDetailDtos)
            {
				var image = _unitOfWork.GetRepository<Image>().Where(x => x.ID == imageDetail.ImageID).First();
				var map = _mapper.Map<ImageDto>(image);
				imageList.Add(map);
			}
			return imageList;
        }
        public List<SortImageDto> GetImageByImageDetailsAndSortImage(List<ImageDetailDto> imageDetailDtos)
        {
            List<SortImageDto> imageList = new List<SortImageDto>();
            foreach (var imageDetail in imageDetailDtos)
            {
                var image = _unitOfWork.GetRepository<Image>().Where(x => x.ID == imageDetail.ImageID).First();
                SortImageDto sortImageDto = new SortImageDto
				{
					ID = image.ID,
					FileName = image.FileName,
					FileType = image.FileType,
					SortImage = imageDetail.SortImage
				};
				imageList.Add(sortImageDto);
            }
            return imageList;
        }
    }
}
