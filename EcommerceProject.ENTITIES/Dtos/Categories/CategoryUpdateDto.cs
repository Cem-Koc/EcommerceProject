using EcommerceProject.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.Categories
{
	public class CategoryUpdateDto
	{
		public int ID { get; set; }
		public string CategoryName { get; set; }
	}
}
