using EcommerceProject.ENTITIES.Dtos.Categories;
using EcommerceProject.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.Products
{
	public class ProductDto
	{
		public int ID { get; set; }
		public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public DataStatus Status { get; set; }
        public CategoryNameDto Category { get; set; }
    }
}
