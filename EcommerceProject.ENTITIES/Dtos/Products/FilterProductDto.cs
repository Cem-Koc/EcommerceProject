using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.Products
{
	public class FilterProductDto
	{
        public string PriceFilter { get; set; }
        public int[] SelectedCategories { get; set; }
        public int[] SelectedProductColors { get; set; }
        public int[] SelectedProductSizes { get; set; }
        public int CustomerTypeID { get; set; }
    }
}
