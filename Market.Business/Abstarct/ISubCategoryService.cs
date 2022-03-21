using Market.DAL.Dto.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.Abstarct
{
    public interface ISubCategoryService
    {
        Task<List<GetListSubCategoryDto>> GetListSubCategories();
        Task<GetSubCategoryDto> GetSubCategoryById(int SubCategoryId);
        Task<int> AddSubCategory(AddSubCategoryDto addSubCategoryDto);
        Task<int> UpdateSubCategory(UpdateSubCategoryDto updateSubCategoryDto);
        Task<int> DeleteSubCategory(int SubCategoryId);

    }
}
