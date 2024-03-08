using EcommerceProject.ENTITIES.Dtos.Orders;
using EcommerceProject.UI.Models.ShoppingTools;

namespace EcommerceProject.UI.Models
{
	public class OrderAddViewModel
	{
        public OrderViewDto orderViewDto { get; set; }
        public Cart cart { get; set; }
    }
}
