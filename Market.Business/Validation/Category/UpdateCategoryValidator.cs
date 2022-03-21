using FluentValidation;
using Market.DAL.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.Validation.Category
{
  public  class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name boş bırakılamaz.").MaximumLength(200).WithMessage("maksımum 200 hane girilebilir.");

        }
    }
}
