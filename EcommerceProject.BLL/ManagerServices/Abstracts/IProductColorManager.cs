using EcommerceProject.ENTITIES.Dtos.ProductColors;
using EcommerceProject.ENTITIES.Models;
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
		Task<string> SafeDeleteProductColorAsync(int productColorID);
		Task<bool> UpdateProductColorAsync(ProductColorUpdateDto productColorUpdateDto);
		Task<bool> CreateProductColorAsync(ProductColorAddDto productColorAddDto);
		Task<ProductColor> FindAsync(int id);
        Task<List<ProductColorDto>> GetProductColorsResultList(List<int> colorIDResult);

    }
}
