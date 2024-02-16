using EcommerceProject.ENTITIES.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.FluentValidations
{
	public class ProductColorValidator:AbstractValidator<ProductColor>
	{
        public ProductColorValidator()
        {
			RuleFor(p => p.Color)
				.NotEmpty()
				.NotNull()
				.MinimumLength(3)
				.MaximumLength(30)
				.WithName("Ürün Rengi");
		}
    }
}
