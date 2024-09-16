using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProductAsync(AddProductDto addProductDto)
        {
            await _productRepository.AddProductAsync(addProductDto);
        }

        public Task<bool> DeleteProductAsync(DeleteProductDto deleteProductDto)
        {
            return _productRepository.DeleteProductAsync(deleteProductDto);
        }

        public List<GetProductDto> GetAll()
        {
           return _productRepository.GetAll();
        }

        public async Task<GetProductDto> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<GetProductDto> GetProductByName(string name)
        {
            return await _productRepository.GetProductByName(name);
        }
    }
}
