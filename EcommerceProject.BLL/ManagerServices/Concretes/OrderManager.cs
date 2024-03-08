using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.Orders;
using EcommerceProject.ENTITIES.Dtos.Products;
using EcommerceProject.ENTITIES.Dtos.Users;
using EcommerceProject.ENTITIES.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
    public class OrderManager : IOrderManager
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;
		private readonly IMapper _mapper;
		private readonly UserManager<AppUser> _userManager;

		public OrderManager(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager)
		{
			_unitOfWork = unitOfWork;
			_httpContextAccessor = httpContextAccessor;
			_user = _httpContextAccessor.HttpContext.User;
			_mapper = mapper;
			_userManager = userManager;
		}

		public async Task<List<MyOrdersDto>> MyOrders()
		{
            var userId = _user.GetLoggedInUserId();

			var userOrders = await _unitOfWork.GetRepository<Order>().GetAllAsync(x=>x.AppUserID == userId);
            var orderDetails = await _unitOfWork.GetRepository<OrderDetail>().GetAllAsync();

            List<MyOrdersDto> myOrdersDtos = new List<MyOrdersDto>();

            foreach (var order in userOrders)
            {
                MyOrdersDto myOrdersDto = new MyOrdersDto();	
				List<ProductImagesWithProductIdDto> productImagesWithProductIdDtos = new List<ProductImagesWithProductIdDto>();

                foreach (var orderDetail in orderDetails)
                {
                    if (orderDetail.OrderID == order.ID)
                    {
						var imageDetail = _unitOfWork.GetRepository<ImageDetail>().Where(x => x.ProductID == orderDetail.ProductID).First();                        

                        ProductImagesWithProductIdDto productImagesWithProductIdDto = new ProductImagesWithProductIdDto 
						{ 
							ProductID = imageDetail.ProductID,
							ImageFileName = imageDetail.Image.FileName
						};

                        myOrdersDto.OrderAmount += (orderDetail.Quantity * (_unitOfWork.GetRepository<Product>().Where(x => x.ID == orderDetail.ProductID).Select(x => x.SalePrice).First()));

                        productImagesWithProductIdDtos.Add(productImagesWithProductIdDto);                        
                    }
                }
				myOrdersDto.productImagesWithProductIdDtos = productImagesWithProductIdDtos;
                myOrdersDto.OrderDate = order.CreatedDate;
				myOrdersDtos.Add(myOrdersDto);
            }
			return myOrdersDtos;
        }

		public async Task<OrderViewDto> CreateOrderAsync(OrderAddDto orderAddDto) 
		{
			var userEmail = _user.GetLoggedInUserEmail();
			var user = await _userManager.FindByEmailAsync(userEmail);

			var orderMap = _mapper.Map<Order>(orderAddDto);

            if (user!=null)
            {
				orderMap.CreatedBy = userEmail;
			}
			else
			{
				orderMap.CreatedBy = orderMap.EmailAddress;
			}
			orderMap.AppUserID = user.Id;
			orderMap.CreatedDate = DateTime.Now;
			await _unitOfWork.GetRepository<Order>().AddAsync(orderMap);
			await _unitOfWork.SaveAsync();

			return _mapper.Map<OrderViewDto>(orderMap);			
		}

        public void Add(Order item)
		{
			_unitOfWork.GetRepository<Order>().Add(item);
			_unitOfWork.Save();
		}

		public async Task AddAsync(Order item)
		{
			await _unitOfWork.GetRepository<Order>().AddAsync(item);
			await _unitOfWork.SaveAsync();
		}

		public void AddRange(List<Order> list)
		{
			_unitOfWork.GetRepository<Order>().AddRange(list);
			_unitOfWork.Save();
		}

		public async Task AddRangeAsync(List<Order> list)
		{
			await _unitOfWork.GetRepository<Order>().AddRangeAsync(list);
			await _unitOfWork.SaveAsync();
		}

		public async Task<bool> AnyAsync(Expression<Func<Order, bool>> exp)
		{
			return await _unitOfWork.GetRepository<Order>().AnyAsync(exp);
		}

		public void Delete(Order item)
		{
			_unitOfWork.GetRepository<Order>().Delete(item);
			_unitOfWork.Save();
		}

		public void DeleteRange(List<Order> list)
		{
			_unitOfWork.GetRepository<Order>().DeleteRange(list);
			_unitOfWork.Save();
		}

		public void Destroy(Order item)
		{
			_unitOfWork.GetRepository<Order>().Destroy(item);
			_unitOfWork.Save();
		}

		public void DestroyRange(List<Order> list)
		{
			_unitOfWork.GetRepository<Order>().DestroyRange(list);
			_unitOfWork.Save();
		}

		public async Task<Order> FindAsync(int id)
		{
			return await _unitOfWork.GetRepository<Order>().FindAsync(id);
		}

		public async Task<Order> FirstOrDefaultAsync(Expression<Func<Order, bool>> exp)
		{
			return await _unitOfWork.GetRepository<Order>().FirstOrDefaultAsync(exp);
		}

		public IQueryable<Order> GetActives()
		{
			return _unitOfWork.GetRepository<Order>().GetActives();
		}

		public IQueryable<Order> GetAll()
		{
			return _unitOfWork.GetRepository<Order>().GetAll();
		}

		public IQueryable<Order> GetModifieds()
		{
			return _unitOfWork.GetRepository<Order>().GetModifieds();
		}

		public IQueryable<Order> GetPassives()
		{
			return _unitOfWork.GetRepository<Order>().GetPassives();
		}

		public IQueryable<X> Select<X>(Expression<Func<Order, X>> exp)
		{
			return _unitOfWork.GetRepository<Order>().Select(exp);
		}

		public async Task Update(Order item)
		{
			await _unitOfWork.GetRepository<Order>().Update(item);
			await _unitOfWork.SaveAsync();
		}

		public async Task UpdateRange(List<Order> list)
		{
			await _unitOfWork.GetRepository<Order>().UpdateRange(list);
			await _unitOfWork.SaveAsync();
		}

		public IQueryable<Order> Where(Expression<Func<Order, bool>> exp)
		{
			return _unitOfWork.GetRepository<Order>().Where(exp);
		}
	}
}
