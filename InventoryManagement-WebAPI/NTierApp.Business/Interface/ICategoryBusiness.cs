using NTier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Business.Interface
{
    public interface ICategoryBusiness
    {
        Category GetById(int categoryId);
        IEnumerable<Category> GetAll();
        void Insert(Category category);
        void Update(Category category);
        void Delete(int categoryId);

    }
}
