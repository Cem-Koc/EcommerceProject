using EcommerceProject.ENTITIES.Dtos.CustomerTypes;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
    public interface ICustomerTypeManager
    {
        public Task<List<CustomerTypeDto>> GetAllCustomerTypesNonDeletedAsync();
		Task<string> SafeDeleteCustomerTypeAsync(int customerTypeID);
		Task<bool> UpdateCustomerTypeAsync(CustomerTypeUpdateDto customerTypeUpdateDto);
		Task<bool> CreateCustomerTypeAsync(CustomerTypeAddDto customerTypeAddDto);
		Task<CustomerType> FindAsync(int id);
	}
}
