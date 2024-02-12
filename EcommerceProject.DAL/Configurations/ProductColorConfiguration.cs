using EcommerceProject.ENTITIES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DAL.Configurations
{
    public class ProductColorConfiguration : BaseConfiguration<ProductColor>
    {
        public override void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            base.Configure(builder);

            builder.HasData(new ProductColor
            {
                ID = 1,
                Color = "Mavi"
            },
            new ProductColor
            {
                ID = 2,
                Color = "Siyah"
            },
            new ProductColor
            {
                ID = 3,
                Color = "Beyaz"
            });
        }
    }
}
