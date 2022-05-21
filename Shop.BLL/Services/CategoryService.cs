using Shop.BLL.DTO;
using Shop.DAL.Context;
using Shop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class CategoryService
    {
        private CategoryRepository categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAllAsync() => await Task.Run(() => GetAll());
        public IEnumerable<CategoryDTO> GetAll()
        {
            //Thread.Sleep(5000);
            return categoryRepository
                .GetAll()
                .Select(category => new CategoryDTO
                {
                    Id = category.CategoryId,
                    Name = category.CategoryName
                });
        }
        public CategoryDTO Get(int id)
        {
            var category = categoryRepository.Get(id);
            return new CategoryDTO 
            { 
                Id = category.CategoryId,
                Name = category.CategoryName
            };
        }
        public void Delete(CategoryDTO categoryDTO)
        {
            var categoryToDelete = categoryRepository.Get(categoryDTO.Id);
            categoryRepository.Delete(categoryToDelete);
            categoryRepository.Save();
        }
        public void Update(CategoryDTO categoryDTO)
        {
            var categoryToEdit = categoryRepository.Get(categoryDTO.Id);
            categoryToEdit.CategoryName = categoryDTO.Name;
            categoryRepository.CreateOrUpdate(categoryToEdit);
            categoryRepository.Save();
        }
        public CategoryDTO Create(CategoryDTO categoryDTO)
        {
            var category = new Category { CategoryName = categoryDTO.Name };
            categoryRepository.CreateOrUpdate(category);
            categoryDTO.Id = category.CategoryId;
            categoryRepository.Save();
            return categoryDTO;
        }
    }
}
