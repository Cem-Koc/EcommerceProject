using EcommerceProject.ENTITIES.Dtos.Categories;
using EcommerceProject.ENTITIES.Dtos.CustomerTypes;
using EcommerceProject.ENTITIES.Dtos.Images;
using EcommerceProject.ENTITIES.Dtos.ProductColors;
using EcommerceProject.ENTITIES.Dtos.ProductSizes;
using EcommerceProject.ENTITIES.Enums;
using EcommerceProject.ENTITIES.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.Products
{
    public class ProductListByCustomerTypeIdDto
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
		public string Description { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal SalePrice { get; set; }
        public string ImageFileName { get; set; }
        public int ProductColorID { get; set; }
        public int ProductSizeID { get; set; }
        public int ProductCode { get; set; }
    }
}
