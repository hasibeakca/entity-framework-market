using FluentValidation;
using Market.DAL.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.Validation.Category
{
  public  class AddCategoryValidator : AbstractValidator<AddCategoryDto>
    {
        public AddCategoryValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name boş geçilemez.")
                .MaximumLength(200).WithMessage("Name boş bırakılamaz");
        }
    }
}
