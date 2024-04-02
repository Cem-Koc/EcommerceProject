using EcommerceProject.ENTITIES.Dtos.ProductCommets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
    public interface IProductCommentManager
    {
        Task<List<ProductCommentDto>> GetCommentsByProductCode(int productCode);
        Task<bool> CommentCreate(string userComment, int productId);
    }
}
