using Market.Business.Abstarct;
using Market.DAL.Dto.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("GetCategoryList")]

        public async Task<ActionResult<List<GetListCategoryDto>>> GetCategoryList()
        {
            try
            {
                return Ok(await _categoryService.GetAllCategories());

            }

            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }
        }

        [HttpGet]
        [Route("GetCategoryById/{id:int}")]

        public async Task<ActionResult<GetCategoryDto>> GetCategory(int id)
        {
            var List = new List<string>();

            if (id <= 0)
            {
                List.Add("Category id geçersiz");
                return Ok(new { code = StatusCode(1001), message = List, type = "error" });
            }
            try
            {
                var currentCategory = await _categoryService.GetCategoryById(id);

                if (currentCategory == null)
                {
                    List.Add("Category bulunamadı.");
                    return Ok(new { code = StatusCode(1001), message = List, type = "error" });
                }
                else
                {
                    return currentCategory;
                }

            }
            catch (Exception hata)
            {

                return BadRequest(hata.Message);
            }

        }
        [HttpPost("AddCategory")]
        public async Task<ActionResult<string>> AddCategory(AddCategoryDto addCategoryDto)
        {
            var list = new List<string>();
            try
            {
                var result = await _categoryService.AddCategory(addCategoryDto);
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
        [Route("UpdateCategory")]
        public async Task<ActionResult<string>> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var list = new List<string>();
            try
            {
                var result = await _categoryService.UpdateCategory(updateCategoryDto);
                if (result > 0)
                {
                    list.Add("Guncelleme basarılı.");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                }
                else if (result == -1)
                {
                    list.Add("CATEGORY BULUNAMADI");
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
        [Route("DeleteCategory/{Id:int}")]
        public async Task<ActionResult<string>> DeleteCategory(int Id)
        {
            var list = new List<string>();
            try
            {
                var result = await _categoryService.DeleteCategory(Id);
                if (result > 0)
                {
                    list.Add("SİLİNME BASARILI");
                    return Ok(new { code = StatusCode(1000), message = list, type = "success" });


                }
                else if (result == -1)
                {
                    list.Add("CATEGORY BULUNAMADI");
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
