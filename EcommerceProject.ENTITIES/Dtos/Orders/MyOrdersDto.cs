using EcommerceProject.ENTITIES.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.Orders
{
    public class MyOrdersDto
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderAmount { get; set; }
        public List<ProductImagesWithProductIdDto> productImagesWithProductIdDtos { get; set; }
    }
}
