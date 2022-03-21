using Market.Business.Abstarct;
using Market.DAL.Context;
using Market.DAL.Dto.Category;
using Market.DAL.Dto.Product;
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
    public class ProductService : IProductService
    {
        private readonly MarketDbContext _marketDbContext; // buraya ben bi değişkenle iş yapıcam değişkenimde bu

        public ProductService(MarketDbContext marketDbContext)
        {
            _marketDbContext = marketDbContext;
        }

        public async Task<int> AddProduct(AddProductDto addProductDto)
        {
            var AddingProduct = new Product
            {
                Name = addProductDto.Name,
                Price = addProductDto.Price,
                SubCategoryId = addProductDto.SubCategoryId
            };
            await _marketDbContext.Products.AddAsync(AddingProduct);
            return await _marketDbContext.SaveChangesAsync();
        }

        public async Task<GetProductDto> GetProducById(int ProductId) // ıDSINE GORE GETIRDIK HANGISININ ID SI OLDUGUNU PARANTEZ ICINE EKLEDIK
        {
            return await _marketDbContext.Products.Include(p => p.SubCategoryFK).Where(p => !p.IsDeleted && p.Id == ProductId).Select(p => new GetProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                SubCategoryId = p.SubCategoryId,
                SubcategoryName = p.SubCategoryFK.Name,


            }).FirstOrDefaultAsync();
        }

        public async Task<List<GetListProductDto>> getListProductDtos()
        {
            return await _marketDbContext.Products.Where(p => !p.IsDeleted).Include(p => p.SubCategoryFK).Select(p => new GetListProductDto
            {

                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                SubCategoryId = p.SubCategoryId,
                SubCategoryName = p.SubCategoryFK.Name,


            }).ToListAsync();
        }

        public async Task<int> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var currentProduct = await _marketDbContext.Products.Where(p => !p.IsDeleted && p.Id == updateProductDto.Id).FirstOrDefaultAsync();
            if (currentProduct == null)
            {
                return -1;
            }

            currentProduct.Name = updateProductDto.Name;
            currentProduct.Price = updateProductDto.Price;
            currentProduct.SubCategoryId = updateProductDto.SubCategoryId;

            _marketDbContext.Products.Update(currentProduct);
            return await _marketDbContext.SaveChangesAsync();

        }

        public async Task<int> DeleteProduct(int ProductId)
        {
            var currentProduct = await _marketDbContext.Products.Where(p => !p.IsDeleted && p.Id == ProductId).FirstOrDefaultAsync();
            if (currentProduct == null)
            {
                return -1;
            }
            currentProduct.IsDeleted = true;
            _marketDbContext.Products.Update(currentProduct);
            return await _marketDbContext.SaveChangesAsync();
        }
    }
}
