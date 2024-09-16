using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.CategoryDTOs;
using ETradeService.Base.Concrete.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CategoryRepository : EfRepositoryBase<Category, PostgreContext>, ICategoryRepository
    {
        public async Task AddCategoryAsync(AddCategoryDto addCategoryDto)
        {
            using (PostgreContext context = new PostgreContext())
            {
                var category = new Category
                {
                    CategoryName = addCategoryDto.CategoryName,

                };
                context.Categories.Add(category);
                await context.SaveChangesAsync();
            }
        }
    }
}
