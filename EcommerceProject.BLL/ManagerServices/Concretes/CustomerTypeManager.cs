using AutoMapper;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.CustomerTypes;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
    public class CustomerTypeManager : ICustomerTypeManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerTypeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CustomerTypeDto>> GetAllCustomerTypesNonDeletedAsync()
        {
            var customerTypes = await _unitOfWork.GetRepository<CustomerType>().GetAllAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
            var map = _mapper.Map<List<CustomerTypeDto>>(customerTypes);
            return map;
        }
    }
}
