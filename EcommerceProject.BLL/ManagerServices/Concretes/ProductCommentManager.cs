using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.ProductCommets;
using EcommerceProject.ENTITIES.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
    public class ProductCommentManager:IProductCommentManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly IAppUserManager _appUserManager;

        public ProductCommentManager(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IAppUserManager appUserManager)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext.User;
            _appUserManager = appUserManager;
        }

        public async Task<List<ProductCommentDto>> GetCommentsByProductCode(int productCode)
        {
            var comments = await _unitOfWork.GetRepository<ProductComment>().GetAllAsync(x=>x.ProductCode == productCode && x.Status != ENTITIES.Enums.DataStatus.Deleted);

            List<ProductCommentDto> productCommentDtos = new List<ProductCommentDto>();

            foreach (var comment in comments)
            {
                var user = await _appUserManager.FindAsync(comment.AppUserID);

                ProductCommentDto productCommentDto = new ProductCommentDto
                {
                    Comment = comment.Comment,
                    CommentDate = comment.CreatedDate,
                    FullName = user.FirstName + " " + user.LastName
                };

                productCommentDtos.Add(productCommentDto);
            }

            return productCommentDtos;
        }

    }
}
