using EcommerceProject.ENTITIES.Dtos.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
	public interface IImageManager
	{
		ImageDto GetByImageID(int imageID);

        List<ImageDto> GetImageByImageDetails(List<ImageDetailDto> imageDetailDtos);
        List<SortImageDto> GetImageByImageDetailsAndSortImage(List<ImageDetailDto> imageDetailDtos);

    }
}
