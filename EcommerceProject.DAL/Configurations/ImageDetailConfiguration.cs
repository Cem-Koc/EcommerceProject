using EcommerceProject.ENTITIES.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DAL.Configurations
{
	public class ImageDetailConfiguration : BaseConfiguration<ImageDetail>
	{
		public override void Configure(EntityTypeBuilder<ImageDetail> builder)
		{
			base.Configure(builder);
			builder.Ignore(x => x.ID);
			builder.HasKey(x => new
			{
				x.ProductID,
				x.ImageID
			});
		}
	}
}
