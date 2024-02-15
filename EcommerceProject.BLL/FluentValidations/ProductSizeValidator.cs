using EcommerceProject.ENTITIES.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.FluentValidations
{
	public class ProductSizeValidator:AbstractValidator<ProductSize>
	{
        public ProductSizeValidator()
        {
			RuleFor(c => c.Size)
				.NotEmpty()
				.NotNull()
				.MinimumLength(1)
				.MaximumLength(20)
				.WithName("Ürün Bedeni");
		}
    }
}
