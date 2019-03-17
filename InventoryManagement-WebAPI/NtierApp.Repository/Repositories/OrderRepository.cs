using NTier.Domain;
using NtierApp.Repository.Infrastucture;
using NtierApp.Repository.Infrastucture.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NtierApp.Repository.Repositories
{
    public class OrderRepository : BaseRepository<Orders>
    {
        public OrderRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    }
}
