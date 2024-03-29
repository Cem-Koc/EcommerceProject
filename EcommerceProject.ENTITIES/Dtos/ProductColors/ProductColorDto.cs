﻿using EcommerceProject.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.ProductColors
{
    public class ProductColorDto
    {
        public int ID { get; set; }
        public string Color { get; set; }
        public string ColorReplaceName { get; set; }
		public DateTime CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DataStatus Status { get; set; }
	}
}
