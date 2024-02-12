using AutoMapper;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.ProductSizes;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
    public class ProductSizeManager : IProductSizeManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductSizeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ProductSizeDto>> GetAllProductSizesNonDeletedAsync()
        {
            var productSizes = await _unitOfWork.GetRepository<ProductSize>().GetAllAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
            var map = _mapper.Map<List<ProductSizeDto>>(productSizes);
            return map;
        }
    }
}
