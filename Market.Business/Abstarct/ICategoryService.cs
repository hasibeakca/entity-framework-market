using Market.DAL.Dto.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.Abstarct
{
  public  interface ICategoryService 
    {
        Task<List<GetListCategoryDto>> GetAllCategories();

        Task<GetCategoryDto> GetCategoryById(int CategoryId);

        Task<int> AddCategory(AddCategoryDto addCategoryDto);
        Task<int> UpdateCategory(UpdateCategoryDto updateCategoryDto);

        Task<int> DeleteCategory(int CategoryId);


    }
}
