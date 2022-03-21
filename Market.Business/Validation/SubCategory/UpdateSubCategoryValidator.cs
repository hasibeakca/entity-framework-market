using FluentValidation;
using Market.DAL.Dto.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.Validation.SubCategory
{
 public   class UpdateSubCategoryValidator : AbstractValidator<UpdateSubCategoryDto>
    {
        public UpdateSubCategoryValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name boş bırakılamaz").MaximumLength(200).WithMessage("200 karakterden fazla giremezsiniz.");
        }
    }
}
