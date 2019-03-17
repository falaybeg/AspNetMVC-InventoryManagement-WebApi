using NTier.Domain;
using NtierApp.Repository.Infrastucture;
using NtierApp.Repository.Infrastucture.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierApp.Repository.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>
    {
        public SupplierRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    }
}
