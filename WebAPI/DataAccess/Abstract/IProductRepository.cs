using Core.DataAccess;
using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductRepository: IEntityRepository<Product>
    {
        List<GetProductDto> GetAll();
        public Task<GetProductDto> GetProductById(int id);
        public Task<GetProductDto> GetProductByName(string name);
        public Task AddProductAsync(AddProductDto addProductDto);
        public Task<bool> DeleteProductAsync(DeleteProductDto deleteProductDto);
    }
}
