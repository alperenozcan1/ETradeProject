using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        Category GetByName(string name);
        void DeleteById(int id);
        public Task AddCategoryAsync(AddCategoryDto addCategoryDto);
        //void Add(Category category);
    }
}
