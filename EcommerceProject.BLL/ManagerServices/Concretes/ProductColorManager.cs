using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.ProductColors;
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
    public class ProductColorManager : IProductColorManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;
		public ProductColorManager(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
			_user = _httpContextAccessor.HttpContext.User;
		}

		public async Task<bool> CreateProductColorAsync(ProductColorAddDto productColorAddDto)
		{
			var user = _user.GetLoggedInUserEmail();

			var productColorResult = _unitOfWork.GetRepository<ProductColor>().Where(x => x.Color == productColorAddDto.Color && x.Status != ENTITIES.Enums.DataStatus.Deleted).ToList();

			if (productColorResult.Count == 0)
			{
				ProductColor productColor = new(productColorAddDto.Color, user);
				await _unitOfWork.GetRepository<ProductColor>().AddAsync(productColor);
				await _unitOfWork.SaveAsync();
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<ProductColor> FindAsync(int id)
		{
			return await _unitOfWork.GetRepository<ProductColor>().FindAsync(id);
		}

		public async Task<List<ProductColorDto>> GetProductColorsNonDeletedAsync()
        {
            var productColors = await _unitOfWork.GetRepository<ProductColor>().GetAllAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
            var map = _mapper.Map<List<ProductColorDto>>(productColors);
            return map;
        }

		public async Task<string> SafeDeleteProductColorAsync(int productColorID)
		{
			var productColor = await _unitOfWork.GetRepository<ProductColor>().FindAsync(productColorID);
			var user = _user.GetLoggedInUserEmail();
			var productColorValue = productColor.Color;
			productColor.DeletedBy = user;
			productColor.DeletedDate = DateTime.Now;
			_unitOfWork.GetRepository<ProductColor>().Delete(productColor);
			await _unitOfWork.SaveAsync();

			return productColorValue;
		}

		public async Task<bool> UpdateProductColorAsync(ProductColorUpdateDto productColorUpdateDto)
		{
			var user = _user.GetLoggedInUserEmail();

			var productColorResult = _unitOfWork.GetRepository<ProductColor>().Where(x => x.Color == productColorUpdateDto.Color && x.Status != ENTITIES.Enums.DataStatus.Deleted).ToList();

			var productColor = await _unitOfWork.GetRepository<ProductColor>().GetAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted && x.ID == productColorUpdateDto.ID);

			if (productColorResult.Count == 0)
			{
				productColor.Color = productColorUpdateDto.Color;
				productColor.ModifiedBy = user;
				productColor.ModifiedDate = DateTime.Now;
				await _unitOfWork.GetRepository<ProductColor>().Update(productColor);
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
