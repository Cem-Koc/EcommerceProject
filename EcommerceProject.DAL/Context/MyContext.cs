using EcommerceProject.DAL.Configurations;
using EcommerceProject.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DAL.Context
{
    public class MyContext:IdentityDbContext<AppUser,AppRole,int,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>
    {
        public MyContext(DbContextOptions<MyContext> opt) : base(opt) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderDetailConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new ProductColorConfiguration());
            builder.ApplyConfiguration(new ProductSizeConfiguration());
            builder.ApplyConfiguration(new CustomerTypeConfiguration());
            builder.ApplyConfiguration(new ImageDetailConfiguration());
            builder.ApplyConfiguration(new LikedProductConfiguration());
            builder.ApplyConfiguration(new ProductCommentConfiguration());
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<ImageDetail> ImageDetails { get; set; }
        public DbSet<LikedProduct> LikedProducts { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
    }
}
