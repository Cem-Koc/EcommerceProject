using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EcommerceProject.UI.Controllers
{
	[Authorize]
	public class LikedProductController : Controller
	{
		private readonly ILikedProductManager _likedProductManager;
		private readonly IToastNotification _toast;
		public LikedProductController(ILikedProductManager likedProductManager, IToastNotification toast)
		{
			_likedProductManager = likedProductManager;
			_toast = toast;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var productList = await _likedProductManager.LikedProductList();
            return View(productList);
		}

		[HttpPost]
		public async Task<IActionResult> LikedProductAdd(int id)
		{
			var result = await _likedProductManager.Add(id);

            if (result)
            {
				_toast.AddSuccessToastMessage("Ürün beğenme işlemi başarılı.", new ToastrOptions { Title = "İşlem Başarılı" });
			}
			else
			{
				_toast.AddErrorToastMessage("Ürün daha önce beğenilmiştir.", new ToastrOptions { Title = "İşlem Başarısız" });
			}
            return View();
		}
	}
}
