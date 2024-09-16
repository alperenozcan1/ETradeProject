using Business.Abstract;
using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeService.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("getall")]
        public List<Category> GetAll()
        {
            return _categoryService.GetAll();
        }
        [HttpPost]
        [Route("add")]
        public async Task AddCategoryAsync(AddCategoryDto addCategoryDto)
        {
            await _categoryService.AddCategoryAsync(addCategoryDto);
        }
        //[HttpPost]
        //public void Add(Category category)
        //{
        //    _categoryService.Add(category);
        //}
        [HttpDelete]
        [Route("delete")]
        public void DeleteById(int id)
        {
            _categoryService.DeleteById(id);
        }
    }
}
