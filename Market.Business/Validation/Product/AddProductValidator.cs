using FluentValidation;
using Market.DAL.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.Validation.Product
{
  public  class AddProductValidator : AbstractValidator<AddProductDto>
    {
        public AddProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name boş bırakılamaz.").MaximumLength(200).WithMessage("200 karakterden fazla giremezsiniz.");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Price boş bırakılamaz");
        }
    }
}
