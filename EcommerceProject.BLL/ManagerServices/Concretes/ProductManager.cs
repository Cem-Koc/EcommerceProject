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

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
    }
}
