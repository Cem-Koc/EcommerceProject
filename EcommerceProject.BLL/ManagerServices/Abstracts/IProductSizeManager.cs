using EcommerceProject.ENTITIES.Dtos.ProductSizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
    public interface IProductSizeManager
    {
        public Task<List<ProductSizeDto>> GetAllProductSizesNonDeletedAsync();
    }
}
