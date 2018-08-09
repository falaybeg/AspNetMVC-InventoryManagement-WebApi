using NTier.Domain;
using NtierApp.Repository;
using NtierApp.Repository.Infrastucture.Contract;
using NTierApp.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Business
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CategoryRepository categoryRepository;

        public CategoryBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this.categoryRepository = new CategoryRepository(_unitOfWork);
        }

        public IEnumerable<Category> GetAll()
        {
            var result = categoryRepository.GetAll();
            return result;
        }

        public Category GetById(int categoryId)
        {
            Category result = null;

            if (categoryId != null)
                result = categoryRepository.GetById(c => c.Id == categoryId);

            return result;
        }

        public void Insert(Category category)
        {
            if (category != null)
                categoryRepository.Insert(category);
        }

        public void Update(Category category)
        {
            if (category != null)
                categoryRepository.Update(category);
        }

        public void Delete(int categoryId)
        {
            if (categoryId != null)
                categoryRepository.Delete(c => c.Id == categoryId);
        }
    }
}
