using EcommerceProject.ENTITIES.Dtos.LikedProducts;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
	public interface ILikedProductManager
	{
		Task<bool> Add(int id);
		Task<List<LikedProductListDto>> LikedProductList();
		IQueryable<OrderDetail> Where(Expression<Func<OrderDetail, bool>> exp);
		IQueryable<OrderDetail> GetAll();
    }
}
