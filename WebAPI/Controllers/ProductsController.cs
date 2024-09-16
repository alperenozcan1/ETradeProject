using Business.Abstract;
using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeService.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("getall")]
        public List<GetProductDto> GetAll()
        {
            return _productService.GetAll();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<GetProductDto> GetProductById(int id)
        {
            return await _productService.GetProductById(id);
        }
        [HttpGet]
        [Route("getbyname/{name}")]
        public async Task<GetProductDto> GetProductByName(string name)
        {
            return await _productService.GetProductByName(name);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddProductAsync(AddProductDto addProductDto)
        {
            await _productService.AddProductAsync(addProductDto);
            return Ok();     
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteProductAsync(DeleteProductDto deleteProductDto)
        {
            var result = await _productService.DeleteProductAsync(deleteProductDto);
            if (!result)
            {
                return NotFound("Product not found!");
            }
            return NoContent();
        }

    }
}
