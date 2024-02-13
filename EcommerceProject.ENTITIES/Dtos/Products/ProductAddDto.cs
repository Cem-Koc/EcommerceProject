using EcommerceProject.ENTITIES.Dtos.Categories;
using EcommerceProject.ENTITIES.Dtos.CustomerTypes;
using EcommerceProject.ENTITIES.Dtos.ProductColors;
using EcommerceProject.ENTITIES.Dtos.ProductSizes;
using Microsoft.AspNetCore.Http;
using EcommerceProject.ENTITIES.Enums;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.Products
{
    public class ProductAddDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int ProductCode { get; set; }        
        public int UnitsInStock { get; set; }    
        public int CategoryID { get; set; }
        public int ProductColorID { get; set; }
        public int ProductSizeID { get; set; }
        public int CustomerTypeID { get; set; }
        public List<CustomerTypeDto> CustomerTypes { get; set; }
		public List<ProductColorDto> ProductColors { get; set; }
		public List<ProductSizeDto> ProductSizes { get; set; }
		public List<CategoryDto> Categories { get; set; }
		public List<ImageDetail> ImageDetails { get; set; }
	}
}
