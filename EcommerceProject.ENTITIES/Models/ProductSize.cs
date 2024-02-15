using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Models
{
    public class ProductSize : BaseEntity
    {
        public ProductSize()
        {
            
        }
        public ProductSize(string size, string createdBy)
        {
            Size = size;
            CreatedBy = createdBy;
        }
        public string Size { get; set; }

        //Relational Properties
        public virtual List<Product> Products { get; set; }
    }
}
