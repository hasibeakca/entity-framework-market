using Market.Business.Abstarct;
using Market.DAL.Context;
using Market.DAL.Dto.SubCategory;
using Market.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Market.Business.Concrete
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly MarketDbContext _marketDbContext;
        public SubCategoryService(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddSubCategory(AddSubCategoryDto addSubCategoryDto)
        {
            var AddingSubCategory = new SubCategory
            {
                Name = addSubCategoryDto.Name,
                CategoryId = addSubCategoryDto.CategoryId

            };
        await _marketDbContext.SubCategories.AddAsync(AddingSubCategory);
            return await _marketDbContext.SaveChangesAsync();
        }



        public async Task<GetSubCategoryDto> GetSubCategoryById(int SubCategoryId)
        {
            return await _marketDbContext.SubCategories.Include(p=> p.CategoryFK)
               .Where(p=> !p.IsDeleted && p.Id == SubCategoryId)
               .Select(p => new GetSubCategoryDto
               {
                   Id = p.Id,
                   Name = p.Name,
                   CategoryName = p.CategoryFK.Name
               }).FirstOrDefaultAsync();
        }
        public async Task< List<GetListSubCategoryDto>> GetListSubCategories()
        {
            return await _marketDbContext.SubCategories.Include(p => p.CategoryFK)
              .Where(p => !p.IsDeleted)
              .Select(p => new GetListSubCategoryDto
              {
                  Id = p.Id,
                  Name = p.Name,
                  CategoryName = p.CategoryFK.Name
              }).ToListAsync();
        }


        public async Task<int> UpdateSubCategory(UpdateSubCategoryDto updateSubCategoryDto)
        {
            var currentSubCategory = await _marketDbContext.SubCategories.Where(p => p.IsDeleted && p.Id == updateSubCategoryDto.Id).FirstOrDefaultAsync();
            if (currentSubCategory == null)
            {
                return -1;
            }
            currentSubCategory.Id = updateSubCategoryDto.Id;
            currentSubCategory.Name = updateSubCategoryDto.Name;
            currentSubCategory.CategoryId = updateSubCategoryDto.CategoryId;
            return await _marketDbContext.SaveChangesAsync();
            

        }
        public async Task< int> DeleteSubCategory(int SubCategoryId)
        {
            var currentSubCategory = await _marketDbContext.SubCategories.Where(p => !p.IsDeleted && p.Id == SubCategoryId).FirstOrDefaultAsync();
            if (currentSubCategory == null)
            {
                return -1;
            };
            currentSubCategory.IsDeleted = true;
            _marketDbContext.SubCategories.Update(currentSubCategory);
            return await _marketDbContext.SaveChangesAsync();

        }

       
    }
}
