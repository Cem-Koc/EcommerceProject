using EcommerceProject.ENTITIES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DAL.Configurations
{
    public class ProductConfiguration:BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.HasMany(x=>x.OrderDetails).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductID).IsRequired();

            builder.HasData(new Product
            {
                ID = 1,
                CategoryID = 1,
                ProductName = "Dar Kesim Bisiklet Yaka Kısa Kollu Tişört",
                Description = "%100 Pamuk Slim Fit",
                UnitPrice = 300,
                SalePrice = 275,
                ProductColorID = 1,
                ProductSizeID = 1,
                CustomerTypeID = 1,
                UnitsInStock = 100,
                ProductCode = 123456
            },
            new Product
            {
                ID = 2,
                CategoryID = 1,
                ProductName = "Dar Kesim Bisiklet Yaka Kısa Kollu Tişört",
                Description = "%100 Pamuk Slim Fit",
                UnitPrice = 300,
                SalePrice = 275,
                ProductColorID = 2,
                ProductSizeID = 1,
                CustomerTypeID = 1,
                UnitsInStock = 100,
                ProductCode = 123456
            },
            new Product
            {
                ID = 3,
                CategoryID = 1,
                ProductName = "Dar Kesim Bisiklet Yaka Kısa Kollu Tişört",
                Description = "%100 Pamuk Slim Fit",
                UnitPrice = 300,
                SalePrice = 275,
                ProductColorID = 1,
                ProductSizeID = 2,
                CustomerTypeID = 1,
                UnitsInStock = 100,
                ProductCode = 123456,
            },
            new Product
            {
                ID = 4,
                CategoryID = 2,
                ProductName = "Sporcu Şort",
                Description = "Slim Fit",
                UnitPrice = 200,
                SalePrice = 175,
                ProductColorID = 2,
                ProductSizeID = 2,
                CustomerTypeID = 2,
                UnitsInStock = 55,
                ProductCode = 112233
            });
        }
    }
}
