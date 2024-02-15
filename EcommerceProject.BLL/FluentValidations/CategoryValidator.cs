using EcommerceProject.ENTITIES.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.FluentValidations
{
	public class CategoryValidator:AbstractValidator<Category>
	{
        public CategoryValidator()
        {
            RuleFor(c=>c.CategoryName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithName("Kategori Adı");
        }
    }
}
