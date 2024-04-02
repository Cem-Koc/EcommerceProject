using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.OrderDetails;
using EcommerceProject.ENTITIES.Dtos.Orders;
using EcommerceProject.ENTITIES.Dtos.Products;
using EcommerceProject.ENTITIES.Models;
using EcommerceProject.UI.Models;
using EcommerceProject.UI.Models.ShoppingTools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.Controllers
{
	[Authorize]
	public class OrderController : Controller
	{
        private readonly IOrderManager _orderManager;
		private readonly IOrderDetailManager _orderDetailManager;
		private readonly IUnitOfWork _unitOfWork;

		public OrderController(IOrderManager orderManager, IOrderDetailManager orderDetailManager, IUnitOfWork unitOfWork)
		{
			_orderManager = orderManager;
			_orderDetailManager = orderDetailManager;
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		public IActionResult Index()
		{
            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(OrderAddDto orderAddDto)
        {
            var createOrder = await _orderManager.CreateOrderAsync(orderAddDto);
			Cart cart = HttpContext.Session.GetObject<Cart>("shoppingCart");

			OrderDetailAddDto orderDetailAddDto = new OrderDetailAddDto();
			orderDetailAddDto.orderViewDto = createOrder;

			List<ProductListByCartDto> productListByCarts = new List<ProductListByCartDto>();

			foreach (var cartItem in cart.MyCart)
            {
				var product = await _unitOfWork.GetRepository<Product>().FindAsync(cartItem.ID);

				ProductListByCartDto productListByCartDto = new ProductListByCartDto();
				productListByCartDto.ID = cartItem.ID;
				productListByCartDto.Amount = cartItem.Amount;
				product.UnitsInStock -= cartItem.Amount;

				productListByCarts.Add(productListByCartDto);
			}

			orderDetailAddDto.productListByCartDtos = productListByCarts;

			await _orderDetailManager.CreateOrderDetail(orderDetailAddDto);

			return View();
        }

		[HttpGet]
		public async Task<IActionResult> MyOrders()
		{
			var myOrders = await _orderManager.MyOrders();
			return View(myOrders);
		}

    }
}
