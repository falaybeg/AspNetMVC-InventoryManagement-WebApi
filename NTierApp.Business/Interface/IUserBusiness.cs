using NTier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Business.Interface
{
    public interface IUserBusiness
    {
        IEnumerable<ApplicationUserr> GetAll();
    }
}
