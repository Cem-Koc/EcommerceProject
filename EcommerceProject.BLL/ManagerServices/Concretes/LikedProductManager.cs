using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.LikedProducts;
using EcommerceProject.ENTITIES.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
	public class LikedProductManager:ILikedProductManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;

		public LikedProductManager(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_httpContextAccessor = httpContextAccessor;
			_user = _httpContextAccessor.HttpContext.User;
		}

        public IQueryable<OrderDetail> GetAll()
        {
            return _unitOfWork.GetRepository<OrderDetail>().GetAll();
        }
        public async Task<List<LikedProductListDto>> LikedProductList()
		{
            var userId = _user.GetLoggedInUserId();
			var likedProducts = await _unitOfWork.GetRepository<LikedProduct>().GetAllAsync(x=>x.AppUserID == userId);

			List<LikedProductListDto> likedProductListDtos = new List<LikedProductListDto>();

            foreach (var likedProduct in likedProducts)
            {
				var product = await _unitOfWork.GetRepository<Product>().GetAsync(x => x.ID == likedProduct.ProductID,x=>x.ProductColor,x=>x.ProductSize,x=>x.ImageDetails);

				var image = product.ImageDetails.First().Image;

                LikedProductListDto likedProductListDto = new LikedProductListDto 
				{
					ID = product.ID,
					ProductColorName = product.ProductColor.Color,
					ProductSizeName = product.ProductSize.Size,
					ProductName = product.ProductName,
					SalePrice = product.SalePrice,
					ImageFileName = image.FileName
                };

                likedProductListDtos.Add(likedProductListDto);
            }

			return likedProductListDtos;
        }

		public async Task<bool> Add(int id)
		{
			var userId = _user.GetLoggedInUserId();
			LikedProduct likedProduct = new LikedProduct();
			likedProduct.AppUserID = userId;
			likedProduct.ProductID = id;

			var result = await _unitOfWork.GetRepository<LikedProduct>().AnyAsync(x=>x.AppUserID==likedProduct.AppUserID && x.ProductID == likedProduct.ProductID);

            if (result)
            {
				return false;
			}
			else 
			{
				await _unitOfWork.GetRepository<LikedProduct>().AddAsync(likedProduct);
				await _unitOfWork.SaveAsync();
				return true;
			}            
		}

        public IQueryable<OrderDetail> Where(Expression<Func<OrderDetail, bool>> exp)
        {
            return _unitOfWork.GetRepository<OrderDetail>().Where(exp);
        }

    }
}
