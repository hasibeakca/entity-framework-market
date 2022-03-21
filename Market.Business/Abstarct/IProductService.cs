using Market.DAL.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Business.Abstarct
{
    public interface IProductService
    {
        Task<List<GetListProductDto>> getListProductDtos();
        Task<GetProductDto> GetProducById(int ProductId);
        Task<int> AddProduct(AddProductDto addProductDto);
        Task<int> UpdateProduct(UpdateProductDto updateProductDto);
        Task<int> DeleteProduct(int ProductId);


    }
}
