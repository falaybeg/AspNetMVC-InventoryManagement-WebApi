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
    public class UserRepository : BaseRepository<ApplicationUserr>
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
