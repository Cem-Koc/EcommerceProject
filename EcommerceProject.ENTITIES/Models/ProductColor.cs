using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Models
{
    public class ProductColor : BaseEntity
    {
        public ProductColor()
        {
            
        }
        public ProductColor(string color, string createdBy)
        {
            Color = color;
            CreatedBy = createdBy;
        }
        public string Color { get; set; }

		//Relational Properties
		public virtual List<Product> Products { get; set; }
    }
}
