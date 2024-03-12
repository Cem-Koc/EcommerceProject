using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.Areas.Admin.ViewComponents
{
    public class DashboardAnnualOrdersCountViewComponent : ViewComponent
    {
        private readonly IOrderManager _orderManager;

        public DashboardAnnualOrdersCountViewComponent(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _orderManager.Where(x=>x.CreatedDate.Year == DateTime.Now.Year).Count();
            return View(result);
        }
    }
}
