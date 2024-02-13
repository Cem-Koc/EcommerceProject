using AutoMapper;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.Products;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.Helpers.Images;
using EcommerceProject.ENTITIES.Dtos.Images;

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IImageHelper _imageHelper;
		private readonly ClaimsPrincipal _user;

		public ProductManager(IUnitOfWork unitOfWork, IMapper mapper,IHttpContextAccessor httpContextAccessor,IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
			_imageHelper = imageHelper;
			_user = _httpContextAccessor.HttpContext.User;
		}


        public async Task<List<ProductDto>> GetAllProductsWithCategoryNonDeletedAsync()
        {
            var products = await _unitOfWork.GetRepository<Product>().GetAllAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted, x => x.Category);
            var map = _mapper.Map<List<ProductDto>>(products);
            return map;
        }

        public async Task<ProductDto> GetProductWithCategoryNonDeletedAsync(int productID)
        {
            var product = await _unitOfWork.GetRepository<Product>().GetAsync(x=>x.Status != ENTITIES.Enums.DataStatus.Deleted && x.ID == productID, x => x.Category,i=>i.ImageDetails);
            var map = _mapper.Map<ProductDto>(product);
            return map;
        }

        public async Task<string> UpdateProductAsync(ProductUpdateDto productUpdateDto)
        {
            var product = await _unitOfWork.GetRepository<Product>().GetAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted && x.ID == productUpdateDto.ID, x => x.Category);
			var user = _user.GetLoggedInUserEmail();
			var productName = product.ProductName;
            product.ModifiedDate = DateTime.Now;
            product.ModifiedBy = user;

            _mapper.Map<ProductUpdateDto,Product>(productUpdateDto,product);

            await _unitOfWork.GetRepository<Product>().Update(product);
            await _unitOfWork.SaveAsync();

            return productName;
		}

        public async Task<string> SafeDeleteProductAsync(int productID)
        {
            var product = await _unitOfWork.GetRepository<Product>().FindAsync(productID);
			var user = _user.GetLoggedInUserEmail();
			var productName = product.ProductName;
            product.DeletedBy = user;
            product.DeletedDate = DateTime.Now;
            _unitOfWork.GetRepository<Product>().Delete(product);
            await _unitOfWork.SaveAsync();

            return productName;
        }

        public void Add(Product item)
        {
            _unitOfWork.GetRepository<Product>().Add(item);
            _unitOfWork.Save();
        }

        public async Task AddAsync(Product item)
        {
            await _unitOfWork.GetRepository<Product>().AddAsync(item);
            await _unitOfWork.SaveAsync();
        }

        public void AddRange(List<Product> list)
        {
            _unitOfWork.GetRepository<Product>().AddRange(list);
            _unitOfWork.Save();
        }

        public async Task AddRangeAsync(List<Product> list)
        {
            await _unitOfWork.GetRepository<Product>().AddRangeAsync(list);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> exp)
        {
            return await _unitOfWork.GetRepository<Product>().AnyAsync(exp);
        }

        public void Delete(Product item)
        {
            _unitOfWork.GetRepository<Product>().Delete(item);
            _unitOfWork.Save();
        }

        public void DeleteRange(List<Product> list)
        {
            _unitOfWork.GetRepository<Product>().DeleteRange(list);
            _unitOfWork.Save();
        }

        public void Destroy(Product item)
        {
            _unitOfWork.GetRepository<Product>().Destroy(item);
            _unitOfWork.Save();
        }

        public void DestroyRange(List<Product> list)
        {
            _unitOfWork.GetRepository<Product>().DestroyRange(list);
            _unitOfWork.Save();
        }

        public async Task<Product> FindAsync(int id)
        {
            return await _unitOfWork.GetRepository<Product>().FindAsync(id);
        }

        public async Task<Product> FirstOrDefaultAsync(Expression<Func<Product, bool>> exp)
        {
            return await _unitOfWork.GetRepository<Product>().FirstOrDefaultAsync(exp);
        }

        public IQueryable<Product> GetActives()
        {
            return _unitOfWork.GetRepository<Product>().GetActives();
        }

        public IQueryable<ProductDto> GetAll()
        {
            //	var products = _unitOfWork.GetRepository<Product>().GetAll();
            //	var map = _mapper.Map<IQueryable<ProductDto>>(products);
            //	return map;
            //	var collection = _db.Patients
            //.ProjectTo<PatientDto>(_mapper.ConfigurationProvider);

            var products = _unitOfWork.GetRepository<Product>().GetAll().ProjectTo<ProductDto>(_mapper.ConfigurationProvider);
            return products;
        }

        public IQueryable<Product> GetModifieds()
        {
            return _unitOfWork.GetRepository<Product>().GetModifieds();
        }

        public IQueryable<Product> GetPassives()
        {
            return _unitOfWork.GetRepository<Product>().GetPassives();
        }

        public IQueryable<X> Select<X>(Expression<Func<Product, X>> exp)
        {
            return _unitOfWork.GetRepository<Product>().Select(exp);
        }

        public async Task Update(Product item)
        {
            await _unitOfWork.GetRepository<Product>().Update(item);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateRange(List<Product> list)
        {
            await _unitOfWork.GetRepository<Product>().UpdateRange(list);
            await _unitOfWork.SaveAsync();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> exp)
        {
            return _unitOfWork.GetRepository<Product>().Where(exp);
        }

		public async Task CreateProductAsync(ProductAddDto productAddDto)
		{
            var user = _user.GetLoggedInUserEmail();

            //var imageUpload = await _imageHelper.Upload(productAddDto.ProductName, productAddDto.MainImage);
            //Image image = new(imageUpload.FullName, productAddDto.MainImage.ContentType, user);
            //await _unitOfWork.GetRepository<Image>().AddAsync(image);

            var product = new Product();
			_mapper.Map<ProductAddDto, Product>(productAddDto, product);
            product.CreatedBy = user;

			await _unitOfWork.GetRepository<Product>().AddAsync(product);

			//ImageDetail imageDetail = new ImageDetail
   //         {
   //             Image = image,
   //             Product = product,
   //             CreatedBy = user
   //         };

			//await _unitOfWork.GetRepository<ImageDetail>().AddAsync(imageDetail);
			await _unitOfWork.SaveAsync();
		}

        public async Task ProductImageUpload(ImagesOperationsDto imagesOperationsDto)
        {
			var user = _user.GetLoggedInUserEmail();

			var imageUpload = await _imageHelper.Upload(imagesOperationsDto.ProductName, imagesOperationsDto.Image);
			Image image = new(imageUpload.FullName, imagesOperationsDto.Image.ContentType, user);
			await _unitOfWork.GetRepository<Image>().AddAsync(image);
			var product = await _unitOfWork.GetRepository<Product>().GetAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted && x.ID == imagesOperationsDto.ID);

            var sortImageValue =  _unitOfWork.GetRepository<ImageDetail>().Where(x=>x.ProductID==product.ID).OrderByDescending(x=>x.SortImage).FirstOrDefault();
            var sortImageMaxValue = 0;

			if (sortImageValue!=null)
            {
				sortImageMaxValue = sortImageValue.SortImage;
			}

            ImageDetail imageDetail = new ImageDetail
			{
				Image = image,
				Product = product,
				CreatedBy = user,
                SortImage = sortImageMaxValue + 1
			};

			await _unitOfWork.GetRepository<ImageDetail>().AddAsync(imageDetail);
			await _unitOfWork.SaveAsync();
		}
	}
}
