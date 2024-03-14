using EcommerceProject.DAL.Context;
using EcommerceProject.DAL.Repositories.Abstracts;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DAL.Repositories.Concretes
{
    public class ProductCommentRepository : BaseRepository<ProductComment>, IProductCommentRepository
    {
        public ProductCommentRepository(MyContext context) : base(context)
        {
        }
    }
}
