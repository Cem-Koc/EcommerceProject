using EcommerceProject.ENTITIES.Dtos.ProductColors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
    public interface IProductColorManager
    {
        public Task<List<ProductColorDto>> GetProductColorsNonDeletedAsync();
    }
}
