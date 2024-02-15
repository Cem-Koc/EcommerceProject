using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.CustomerTypes;
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
    public class CustomerTypeManager : ICustomerTypeManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;
		public CustomerTypeManager(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
			_user = _httpContextAccessor.HttpContext.User;
        }

		public async Task<bool> CreateCustomerTypeAsync(CustomerTypeAddDto customerTypeAddDto)
		{
			var user = _user.GetLoggedInUserEmail();

			var customerTypeResult = _unitOfWork.GetRepository<CustomerType>().Where(x => x.CustomerTypeName == customerTypeAddDto.CustomerTypeName && x.Status != ENTITIES.Enums.DataStatus.Deleted).ToList();

            if (customerTypeResult.Count == 0)
            {
				CustomerType customerType = new(customerTypeAddDto.CustomerTypeName, user);
				await _unitOfWork.GetRepository<CustomerType>().AddAsync(customerType);
				await _unitOfWork.SaveAsync();
				return true;
			}
			else
			{
				return false;
			}
        }

		public async Task<List<CustomerTypeDto>> GetAllCustomerTypesNonDeletedAsync()
        {
            var customerTypes = await _unitOfWork.GetRepository<CustomerType>().GetAllAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
            var map = _mapper.Map<List<CustomerTypeDto>>(customerTypes);
            return map;
        }

		public async Task<string> SafeDeleteCustomerTypeAsync(int customerTypeID)
		{
			var customerType = await _unitOfWork.GetRepository<CustomerType>().FindAsync(customerTypeID);
			var user = _user.GetLoggedInUserEmail();
			var customerTypeName = customerType.CustomerTypeName;
			customerType.DeletedBy = user;
			customerType.DeletedDate = DateTime.Now;
			_unitOfWork.GetRepository<CustomerType>().Delete(customerType);
			await _unitOfWork.SaveAsync();

			return customerTypeName;
		}

		public async Task<bool> UpdateCustomerTypeAsync(CustomerTypeUpdateDto customerTypeUpdateDto)
		{
			var user = _user.GetLoggedInUserEmail();

			var customerTypeResult = _unitOfWork.GetRepository<CustomerType>().Where(x => x.CustomerTypeName == customerTypeUpdateDto.CustomerTypeName && x.Status != ENTITIES.Enums.DataStatus.Deleted).ToList();

			var customerType = await _unitOfWork.GetRepository<CustomerType>().GetAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted && x.ID == customerTypeUpdateDto.ID);

			if (customerTypeResult.Count == 0)
			{
				customerType.CustomerTypeName = customerTypeUpdateDto.CustomerTypeName;
				customerType.ModifiedBy = user;
				customerType.ModifiedDate = DateTime.Now;
				await _unitOfWork.GetRepository<CustomerType>().Update(customerType);
				await _unitOfWork.SaveAsync();
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<CustomerType> FindAsync(int id)
		{
			return await _unitOfWork.GetRepository<CustomerType>().FindAsync(id);
		}
	}
}
