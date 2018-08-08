using NTier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Business.Interface
{
    public interface ISupplierBusiness
    {
        Supplier GetById(int supplierId);
        IEnumerable<Supplier> GetAll();
        void Insert(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(int supplierId);
    }
}
