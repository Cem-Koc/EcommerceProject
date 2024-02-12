using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.BLL.ManagerServices.Concretes;
using EcommerceProject.DAL.Repositories.Abstracts;
using EcommerceProject.DAL.Repositories.Concretes;
using EcommerceProject.DAL.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.DependencyResolvers
{
    public static class RepositoryManagerServiceInjection
    {
        public static IServiceCollection AddRepositoryManagerServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderDetailManager, OrderDetailManager>();
            services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
            services.AddScoped<IProductSizeManager, ProductSizeManager>();
            services.AddScoped<IProductColorRepository, ProductColorRepository>();
            services.AddScoped<IProductColorManager, ProductColorManager>();
            services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();
            services.AddScoped<ICustomerTypeManager, CustomerTypeManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(assembly);

            return services;

        }
    }
}