using EcommerceProject.BLL.DependencyResolvers;
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
                var product = await _unitOfWork.GetRepository<Product>().GetAsync(x=>x.ID == comment.ProductID,x=>x.ProductColor,x=>x.ProductSize);

                ProductCommentDto productCommentDto = new ProductCommentDto
                {
                    Comment = comment.Comment,
                    CommentDate = comment.CreatedDate,
                    FullName = user.FirstName + " " + user.LastName,
                    ProductColorName = product.ProductColor.Color,
                    ProductSizeName = product.ProductSize.Size
                };

                productCommentDtos.Add(productCommentDto);
            }

            return productCommentDtos;
        }

        public async Task<bool> CommentCreate(string userComment, int productId)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInUserEmail();
            var product = await _unitOfWork.GetRepository<Product>().FindAsync(productId);

            var registeredComment = _unitOfWork.GetRepository<ProductComment>().Where(x=>x.ProductID == productId && x.AppUserID == userId).FirstOrDefault();

            if (registeredComment == null)
            {
                ProductComment productComment = new ProductComment
                {
                    AppUserID = userId,
                    ProductID = productId,
                    Comment = userComment,
                    ProductCode = product.ProductCode,
                    CreatedBy = userEmail
                };

                await _unitOfWork.GetRepository<ProductComment>().AddAsync(productComment);
                await _unitOfWork.SaveAsync();
                return true;
            }
            
            return false;           
        }

    }
}
