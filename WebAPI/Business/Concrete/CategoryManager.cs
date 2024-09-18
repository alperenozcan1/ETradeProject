using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //public void Add(Category category)
        //{
        //    _categoryRepository.Add(category);
        //}

        public async Task AddCategoryAsync(AddCategoryDto addCategoryDto)
        {
            if (addCategoryDto.CategoryName.Length < 2)
            {
                throw new Exception("Category name must be at least 2 characters long. ");
            }
           await _categoryRepository.AddCategoryAsync(addCategoryDto);
        }

        public void DeleteById(int id)
        {
            _categoryRepository.Delete(GetById(id));
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
           return _categoryRepository.Get(c=>c.Id == id);
        }

        public Category GetByName(string name)
        {
            return _categoryRepository.Get(c => c.CategoryName == name);
        }
    }
}
