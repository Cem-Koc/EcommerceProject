using EcommerceProject.ENTITIES.Dtos.LikedProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
	public interface ILikedProductManager
	{
		Task<bool> Add(int id);
		Task<List<LikedProductListDto>> LikedProductList();

    }
}
