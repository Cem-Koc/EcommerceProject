using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.Categories
{
	public class CategoriesByCustomerTypeDto
	{
		public string CustomerTypeName { get; set; }
		public int CustomerTypeId { get; set; }
		public List<CategorySideMenuDto> Categories { get; set; }
	}
}
