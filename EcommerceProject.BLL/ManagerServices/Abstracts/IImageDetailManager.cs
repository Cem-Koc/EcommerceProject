using EcommerceProject.ENTITIES.Dtos.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
	public interface IImageDetailManager
	{
		List<ImageDetailDto> GetImageDetailsByProductID(int productID);
		Task<bool> AssignmentImageDetailsByProductID(int productSourceID, int productDestinationID);

    }
}
