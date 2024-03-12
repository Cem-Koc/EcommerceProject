using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.Areas.Admin.ViewComponents
{
    public class DashboardMonthlyIncomeViewComponent:ViewComponent
    {
        private readonly IOrderDetailManager _orderDetailManager;

        public DashboardMonthlyIncomeViewComponent(IOrderDetailManager orderDetailManager)
        {
            _orderDetailManager = orderDetailManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var orderDetailResult = _orderDetailManager.Where(x=>x.CreatedDate.Month == DateTime.Now.Month && x.CreatedDate.Year == DateTime.Now.Year).ToList();

            var result = orderDetailResult.Sum(x => x.Product.SalePrice * x.Quantity);

            return View(result);
        }
    }
}
