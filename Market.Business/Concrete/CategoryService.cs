using Market.Business.Abstarct;
using Market.DAL.Context;
using Market.DAL.Dto.Category;
using Market.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly MarketDbContext _marketDbContext;
        public CategoryService(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddCategory(AddCategoryDto addCategoryDto)
        {
            var addingCategory = new Category
            {
                Name = addCategoryDto.Name
            };
           await _marketDbContext.Categories.AddAsync(addingCategory);
            return  await _marketDbContext.SaveChangesAsync();
          


        }

        public async Task<int> DeleteCategory(int CategoryId)
        {
            var currentCategory = await _marketDbContext.Categories.Where(p => !p.IsDeleted && p.Id == CategoryId).FirstOrDefaultAsync();
            if(currentCategory == null)
            {
                return -1;
            }
            currentCategory.IsDeleted = true;
            _marketDbContext.Categories.Update(currentCategory);
            return await _marketDbContext.SaveChangesAsync();



        }

        public async Task<List<GetListCategoryDto>> GetAllCategories()
        {
            return await _marketDbContext.Categories.Where(p => !p.IsDeleted).Select(p => new GetListCategoryDto // ısdeleted sılınmemıs olmasını kontrol eder dıegrı esıtlemeyı
            {
                Id = p.Id,
                Name = p.Name,

            }).ToListAsync();


        }

        public async Task< GetCategoryDto> GetCategoryById(int CategoryId)
        {
            return await _marketDbContext.Categories.Where(p => !p.IsDeleted && p.Id == CategoryId).Select(p => new GetCategoryDto // ısdeleted sılınmemıs olmasını kontrol eder dıegrı esıtlemeyı
            {
                Id = p.Id,
                Name = p.Name,

            }).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var currentCategory = await _marketDbContext.Categories.Where(p => !p.IsDeleted && p.Id == updateCategoryDto.Id).FirstOrDefaultAsync();
            if (currentCategory == null)
            {
                return -1;
            }

            currentCategory.Name = updateCategoryDto.Name;
            return await _marketDbContext.SaveChangesAsync();


        }
    }
}
