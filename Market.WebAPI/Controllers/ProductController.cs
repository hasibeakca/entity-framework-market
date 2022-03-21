using Market.Business.Abstarct;
using Market.DAL.Dto.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet]
        [Route("GetProductList")]

        public async Task<ActionResult<List<GetListProductDto>>> GetListProduct()
        {
            try
            {
                return Ok(await _productService.getListProductDtos());
            }

            catch (Exception hata)
            {
                return BadRequest(hata.Message);

            }
        }
        [HttpGet]
        [Route("GetProduct/{id:int}")]
        public async Task<ActionResult<GetProductDto>> GetProduct(int id)
        {
            var List = new List<string>();
            if (id <= 0)
            {
                List.Add("Product Id gecersiz");

                return Ok(new { code = StatusCode(1001), Message = List, type = "error" });
            }
            try
            {
                var currentProduct = await _productService.GetProducById(id);

                if (currentProduct == null)
                {
                    List.Add("Product bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = List, type = "error" });
                }
                else
                {
                    return currentProduct;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult<string>> AddProduct(AddProductDto addProductDto)
        {
            var list = new List<string>();
            try
            {
                var result = await _productService.AddProduct(addProductDto);
                if (result > 0)
                {
                    list.Add("EKLEME İŞLEMİ BAŞARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });

                }
                else
                {
                    list.Add("EKLEME İŞLEMİ BAŞARISIZ.");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult<string>> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var list = new List<string>();
            try
            {
                var result = await _productService.UpdateProduct(updateProductDto);
                if (result > 0)
                {
                    list.Add("Guncelleme basarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("PRODUCT BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
                else
                {
                    list.Add("Guncelleme basarısız");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }


            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteProduct/{Id:int}")]
        public async Task<ActionResult<string>> DeleteProduct(int Id)
        {
            var list = new List<string>();
            try
            {
                var result = await _productService.DeleteProduct(Id);
                if (result > 0)
                {
                    list.Add("SİLİNME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });


                }
                else if (result == -1)
                {
                    list.Add("PRODUCT BULUNAMADI");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });

                }
                else
                {
                    list.Add("SİLİNME BAŞARISIZ");
                    return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }

        }
    }
}
