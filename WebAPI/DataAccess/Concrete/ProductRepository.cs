using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.ProductDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ProductRepository : EfRepositoryBase<Product, PostgreContext>, IProductRepository
    {
        public List<GetProductDto> GetAll()
        {
            using (PostgreContext context = new PostgreContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.Id
                             select new GetProductDto
                             {
                                 Id = p.Id,
                                 CategoryId = c.Id,
                                 ProductName = p.ProductName,
                                 UnitPrice = p.UnitPrice,
                                 UnitsInStock = p.UnitsInStock,
                                 CategoryName = c.CategoryName,
                             };
                return result.ToList();
            }
        }
        public async Task<GetProductDto> GetProductById(int id)
        {
            using (PostgreContext context=new PostgreContext())
            {
                var result = await (from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.Id
                             where id == p.Id
                             select new GetProductDto
                             {
                                 Id = p.Id,
                                 CategoryId = c.Id,
                                 ProductName = p.ProductName,
                                 UnitPrice = p.UnitPrice,
                                 UnitsInStock = p.UnitsInStock,
                                 CategoryName = c.CategoryName,
                             }).FirstOrDefaultAsync();
                return result;
            }
            
        }

        public async Task<GetProductDto> GetProductByName(string name)
        {
            using (PostgreContext context = new PostgreContext())
            {
                var result = await (from p in context.Products
                                    join c in context.Categories on p.CategoryId equals c.Id
                                    where name == p.ProductName
                                    select new GetProductDto
                                    {
                                        Id = p.Id,
                                        CategoryId = c.Id,
                                        ProductName = p.ProductName,
                                        UnitPrice = p.UnitPrice,
                                        UnitsInStock = p.UnitsInStock,
                                        CategoryName = c.CategoryName,
                                    }).FirstOrDefaultAsync();
                return result;
            }
        }
        public async Task AddProductAsync(AddProductDto addProductDto)
        {
            using (PostgreContext context = new PostgreContext())
            {
                var product = new Product
                {
                    ProductName = addProductDto.ProductName,
                    UnitsInStock = addProductDto.UnitsInStock,
                    UnitPrice = addProductDto.UnitPrice,
                    CategoryId = addProductDto.CategoryId,
                };
                context.Products.Add(product);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteProductAsync(DeleteProductDto deleteProductDto)
        {
            using (PostgreContext context = new PostgreContext())
            {
                var product = await context.Products.FindAsync(deleteProductDto.Id);
                if (product == null)
                {
                    return false;
                }

                context.Products.Remove(product);
                await context.SaveChangesAsync();

                return true;
            }
        }


    }
}
