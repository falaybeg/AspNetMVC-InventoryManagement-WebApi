using NTier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Business.Interface
{
    public interface IProductBusiness
    {
        Product GetById(int productId);
        IEnumerable<Product> GetAll();
        void Insert(Product product);
        void Update(Product product);
        void Delete(int productId);
    }
}
