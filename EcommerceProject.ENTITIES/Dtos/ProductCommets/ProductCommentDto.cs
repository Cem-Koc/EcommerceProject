using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.ProductCommets
{
    public class ProductCommentDto
    {
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public string FullName { get; set; }
    }
}
