using EcommerceProject.ENTITIES.Dtos.Categories;
using EcommerceProject.ENTITIES.Dtos.Images;
using EcommerceProject.ENTITIES.Dtos.ProductColors;
using EcommerceProject.ENTITIES.Dtos.ProductSizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.Products
{
	public class ProductDetailDto
	{
        public int ID { get; set; }
        public string ProductName { get; set; }
		public string Description { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal SalePrice { get; set; }
		public int ProductColorID { get; set; }
		public int ProductCode { get; set; }
		public int ProductSizeID { get; set; }
		public int UnitsInStock { get; set; }
		public string CustomerTypeName { get; set; }
		public string CategoryName { get; set; }
		public List<ProductColorByProductIdDto> ProductColors { get; set; }
		public List<ProductSizeByProductIdDto> ProductSizes { get; set; }
		public List<SortImageDto> Images { get; set; }
	}
}
