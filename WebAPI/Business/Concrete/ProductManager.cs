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
            if (string.IsNullOrEmpty(addProductDto.ProductName) || addProductDto.ProductName.Length < 2 )
            {             
                throw new Exception("Product name must be at least 2 characters long.");
            }
            else if(addProductDto.UnitPrice<5)
            {
                throw new Exception("Product price is must be more expensive the 5TL");
            }

            await _productRepository.AddProductAsync(addProductDto);
        }

        public Task<bool> DeleteProductAsync(DeleteProductDto deleteProductDto)
        {
            if (deleteProductDto.Id < 1)
            {
                throw new Exception("Invalid ID value");
            }
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
