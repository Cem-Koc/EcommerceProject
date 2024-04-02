using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EcommerceProject.UI.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {

        private readonly IToastNotification _toast;
        private readonly IProductCommentManager _productCommentManager;

        public CommentController(IToastNotification toast, IProductCommentManager productCommentManager)
        {
            _toast = toast;
            _productCommentManager = productCommentManager;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string comment, int Id)
        {
            var result = await _productCommentManager.CommentCreate(comment, Id);

            if (result == true)
            {
                _toast.AddSuccessToastMessage("Yorumunuz başarılı bir şekilde iletilmiştir.", new ToastrOptions { Title = "İşlem Başarılı" });
            }
            else
            {
                _toast.AddErrorToastMessage("Ürün için daha önce yorumunuz alınmıştır.", new ToastrOptions { Title = "İşlem Başarısız" });
            }
            
            return View();
        }
    }
}
