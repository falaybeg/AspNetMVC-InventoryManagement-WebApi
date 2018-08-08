using NTier.Domain;
using NtierApp.Repository.Infrastucture;
using NtierApp.Repository.Infrastucture.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierApp.Repository
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        
    }
}
