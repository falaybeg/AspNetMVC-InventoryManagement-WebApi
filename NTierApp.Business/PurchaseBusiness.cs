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
    public class PurchaseBusiness : IPurchaseBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PurchaseRepository _purchaseRepository;

        public PurchaseBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._purchaseRepository = new PurchaseRepository(_unitOfWork);
        }

        public IEnumerable<Purchase> GetAll()
        {
            var result = _purchaseRepository.GetAll();
            return result;
        }

        public Purchase GetById(int purchaseId)
        {
            Purchase result = null;
            if (purchaseId != null)
                result = _purchaseRepository.GetById(x => x.Id == purchaseId);
            return result;
        }

        public void Insert(Purchase purchase)
        {
            if (purchase != null)
            {
                purchase.PurchasedTime = DateTime.Now;
                _purchaseRepository.Insert(purchase);
            }
        }

        public void Update(Purchase purchase)
        {
            if (purchase != null)
            {
                purchase.PurchasedTime = DateTime.Now;
                _purchaseRepository.Update(purchase);
            }
        }

        public void Delete(int purchaseId)
        {
            if (purchaseId != null)
                _purchaseRepository.Delete(x => x.Id == purchaseId);
        }

    }
}
