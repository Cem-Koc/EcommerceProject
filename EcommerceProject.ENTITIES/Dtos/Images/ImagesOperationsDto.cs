﻿using EcommerceProject.ENTITIES.Dtos.Categories;
using EcommerceProject.ENTITIES.Dtos.CustomerTypes;
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

namespace EcommerceProject.ENTITIES.Dtos.Images
{
	public class ImagesOperationsDto
	{
		public int ID { get; set; }
		public string ProductName { get; set; }
		public int ProductCode { get; set; }
		public int CategoryID { get; set; }
		public int ProductColorID { get; set; }
		public int ProductSizeID { get; set; }
		public int CustomerTypeID { get; set; }
		public IFormFile Image { get; set; }
        public int SelectedImageID { get; set; }
        public List<CustomerTypeDto> CustomerTypes { get; set; }
		public List<ProductColorDto> ProductColors { get; set; }
		public List<ProductSizeDto> ProductSizes { get; set; }
		public List<CategoryDto> Categories { get; set; }
        public List<ImageDetailDto> ImageDetails { get; set; }
        public List<ImageDto> Images { get; set; }
    }
}
