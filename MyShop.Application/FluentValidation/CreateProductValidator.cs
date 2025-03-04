using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyShop.Application.Vm.Product;
namespace MyShop.Application.FluentValidation
{
    public class CreateProductValidator:AbstractValidator<ProductVm>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("نام مصحول نباید خالی باشد");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("طول وارد شده بیشتر از حد مجاز هست");
           
        }
    }
}
