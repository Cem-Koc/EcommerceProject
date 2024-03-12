﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.Products
{
	public class RecommendedProductDto
	{
		public int ID { get; set; }
		public string ProductName { get; set; }
		public string ImageFileName { get; set; }
		public decimal SalePrice { get; set; }
	}
}
