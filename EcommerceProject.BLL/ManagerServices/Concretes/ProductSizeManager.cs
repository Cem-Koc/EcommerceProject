using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.ProductSizes;
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
    public class ProductSizeManager : IProductSizeManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;
		public ProductSizeManager(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
			_user = _httpContextAccessor.HttpContext.User;
		}

		public async Task<bool> CreateProductSizeAsync(ProductSizeAddDto productSizeAddDto)
		{
			var user = _user.GetLoggedInUserEmail();

			var productSizeResult = _unitOfWork.GetRepository<ProductSize>().Where(x => x.Size == productSizeAddDto.Size && x.Status != ENTITIES.Enums.DataStatus.Deleted).ToList();

			if (productSizeResult.Count == 0)
			{
				ProductSize productSize = new(productSizeAddDto.Size, user);
				await _unitOfWork.GetRepository<ProductSize>().AddAsync(productSize);
				await _unitOfWork.SaveAsync();
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<ProductSize> FindAsync(int id)
		{
			return await _unitOfWork.GetRepository<ProductSize>().FindAsync(id);
		}

		public async Task<List<ProductSizeDto>> GetAllProductSizesNonDeletedAsync()
        {
            var productSizes = await _unitOfWork.GetRepository<ProductSize>().GetAllAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
            var map = _mapper.Map<List<ProductSizeDto>>(productSizes);
            return map;
        }

		public async Task<string> SafeDeleteProductSizeAsync(int productSizeID)
		{
			var productSize = await _unitOfWork.GetRepository<ProductSize>().FindAsync(productSizeID);
			var user = _user.GetLoggedInUserEmail();
			var productSizeValue = productSize.Size;
			productSize.DeletedBy = user;
			productSize.DeletedDate = DateTime.Now;
			_unitOfWork.GetRepository<ProductSize>().Delete(productSize);
			await _unitOfWork.SaveAsync();

			return productSizeValue;
		}

		public async Task<bool> UpdateProductSizeAsync(ProductSizeUpdateDto productSizeUpdateDto)
		{
			var user = _user.GetLoggedInUserEmail();

			var productSizeResult = _unitOfWork.GetRepository<ProductSize>().Where(x => x.Size == productSizeUpdateDto.Size && x.Status != ENTITIES.Enums.DataStatus.Deleted).ToList();

			var productSize = await _unitOfWork.GetRepository<ProductSize>().GetAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted && x.ID == productSizeUpdateDto.ID);

			if (productSizeResult.Count == 0)
			{
				productSize.Size = productSizeUpdateDto.Size;
				productSize.ModifiedBy = user;
				productSize.ModifiedDate = DateTime.Now;
				await _unitOfWork.GetRepository<ProductSize>().Update(productSize);
				await _unitOfWork.SaveAsync();
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
