using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.ProductColors
{
    public class ProductColorByProductIdDto
    {
        public int ID { get; set; }
        public string Color { get; set; }
        public string ColorReplaceName { get; set; }
        public int ProductId { get; set; }
    }
}
