using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.LikedProducts
{
    public class LikedProductListDto
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal SalePrice { get; set; }
        public string ProductColorName { get; set; }
        public string ProductSizeName { get; set; }
        public string ImageFileName { get; set; }
    }
}
