using EcommerceProject.ENTITIES.Dtos.Orders;
using EcommerceProject.ENTITIES.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.OrderDetails
{
	public class OrderDetailAddDto
	{
        public List<ProductListByCartDto> productListByCartDtos { get; set; }
        public OrderViewDto orderViewDto { get; set; }
    }
}
