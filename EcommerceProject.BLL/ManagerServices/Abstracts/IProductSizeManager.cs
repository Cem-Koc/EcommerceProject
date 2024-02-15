using EcommerceProject.ENTITIES.Dtos.ProductSizes;
using EcommerceProject.ENTITIES.Models;
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
		Task<string> SafeDeleteProductSizeAsync(int productSizeID);
		Task<bool> UpdateProductSizeAsync(ProductSizeUpdateDto productSizeUpdateDto);
		Task<bool> CreateProductSizeAsync(ProductSizeAddDto productSizeAddDto);
		Task<ProductSize> FindAsync(int id);
	}
}
