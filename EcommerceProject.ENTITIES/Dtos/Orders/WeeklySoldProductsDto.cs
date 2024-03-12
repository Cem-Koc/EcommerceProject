using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.Orders
{
    public class WeeklySoldProductsDto
    {
        public int[] ProductCount { get; set; }
        public string[] DateNames { get; set; }
    }
}
