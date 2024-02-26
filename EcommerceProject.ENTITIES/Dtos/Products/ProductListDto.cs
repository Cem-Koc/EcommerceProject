using EcommerceProject.ENTITIES.Dtos.Categories;
using EcommerceProject.ENTITIES.Dtos.ProductColors;
using EcommerceProject.ENTITIES.Dtos.ProductSizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.Products
{
	public class ProductListDto
	{
        public List<ProductListByCustomerTypeIdDto> Products { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<ProductColorDto> ProductColors { get; set; }
        public List<ProductSizeDto> ProductSizes { get; set; }
        public int CustomerTypeID { get; set; }
        public int CategorySideMenuSelectedID { get; set; }
    }
}
