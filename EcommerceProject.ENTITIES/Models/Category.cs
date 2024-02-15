using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Models
{
    public class Category:BaseEntity
    {
        public Category()
        {
            
        }
        public Category(string name,string createdBy)
        {
            CategoryName = name;
            CreatedBy = createdBy;
        }
        public string CategoryName { get; set; }

        //Relational Properties
        public virtual List<Product> Products { get; set; }
    }
}
