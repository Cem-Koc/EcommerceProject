using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Models
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int ProductCode { get; set; }
        public int ProductColorID { get; set; }
        public int ProductSizeID { get; set; }
        public int UnitsInStock { get; set; }
        public int CustomerTypeID { get; set; }
        public int? CategoryID { get; set; }

        //Relational Properties
        public virtual Category Category { get; set; }
        public virtual List<ImageDetail> ImageDetails { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual ProductColor ProductColor { get; set; }
        public virtual ProductSize ProductSize { get; set; }
        public virtual CustomerType CustomerType { get; set; }
    }
}
