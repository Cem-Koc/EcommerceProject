using EcommerceProject.ENTITIES.Dtos.CustomerTypes;
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
    }
}
