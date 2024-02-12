using EcommerceProject.ENTITIES.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.FluentValidations
{
	public class ProductValidator:AbstractValidator<Product>
	{
        public ProductValidator()
        {
            RuleFor(x=>x.ProductName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(150)
                .WithName("Ürün İsmi");

            RuleFor(x=>x.Description)
				.NotEmpty()
				.NotNull()
				.MinimumLength(3)
				.MaximumLength(150)
				.WithName("Ürün Açıklaması");


		}
    }
}
