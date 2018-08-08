using NTier.Domain;
using NtierApp.Repository.Infrastucture.Contract;
using NtierApp.Repository.Repositories;
using NTierApp.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Business
{
    public class SupplierBusiness : ISupplierBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SupplierRepository _supplierRepository;

        public SupplierBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._supplierRepository = new SupplierRepository(_unitOfWork);
        }

        public IEnumerable<Supplier> GetAll()
        {
            var result = _supplierRepository.GetAll();
            return result;
        }

        public Supplier GetById(int supplierId)
        {
            Supplier result = null;

            if (supplierId != null)
                result = _supplierRepository.GetById(c => c.Id == supplierId);

            return result;
        }

        public void Insert(Supplier supplier)
        {
            if (supplier != null)
                _supplierRepository.Insert(supplier);
        }

        public void Update(Supplier supplier)
        {
            if (supplier != null)
                _supplierRepository.Update(supplier);
        }

        public void Delete(int supplierId)
        {
            if (supplierId != null)
                _supplierRepository.Delete(x=>x.Id == supplierId);
        }
    }
}
