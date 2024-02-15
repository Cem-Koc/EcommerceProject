using EcommerceProject.ENTITIES.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.FluentValidations
{
	public class CustomerTypeValidator:AbstractValidator<CustomerType>
	{
        public CustomerTypeValidator()
        {
			RuleFor(c => c.CustomerTypeName)
				.NotEmpty()
				.NotNull()
				.MinimumLength(3)
				.MaximumLength(100)
				.WithName("Müşteri Tip Adı");
		}
    }
}
