using NTier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Business.Interface
{
    public interface IPurchaseBusiness
    {
        Purchase GetById(int purchaseId);
        IEnumerable<Purchase> GetAll();
        void Insert(Purchase purchase);
        void Update(Purchase purchase);
        void Delete(int purchaseId);
        void ConfirmPurchase(int purchaseId);
        void UnconfirmPurchase(int purchaseId);
    }
}
