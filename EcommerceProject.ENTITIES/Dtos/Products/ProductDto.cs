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
		public decimal UnitPrice { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
