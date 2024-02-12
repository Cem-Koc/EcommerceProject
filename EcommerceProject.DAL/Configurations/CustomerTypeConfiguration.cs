using EcommerceProject.ENTITIES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DAL.Configurations
{
    public class CustomerTypeConfiguration : BaseConfiguration<CustomerType>
    {
        public override void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            base.Configure(builder);

            builder.HasData(new CustomerType
            {
                ID = 1,
                CustomerTypeName = "Kadın"
            },
            new CustomerType
            {
                ID = 2,
                CustomerTypeName = "Erkek"
            });
        }
    }
}
