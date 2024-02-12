using EcommerceProject.ENTITIES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DAL.Configurations
{
    public class ProductSizeConfiguration : BaseConfiguration<ProductSize>
    {
        public override void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            base.Configure(builder);

            builder.HasData(new ProductSize
            {
                ID = 1,
                Size = "XS"
            },
            new ProductSize
            {
                ID= 2,
                Size = "S"
            },
            new ProductSize
            {
                ID = 3,
                Size = "M"
            });
        }
    }
}
