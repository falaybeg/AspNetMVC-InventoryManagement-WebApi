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
    public class UserBusiness : IUserBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly UserRepository _userRepository;

        public UserBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            this._userRepository = new UserRepository(unitOfWork);
        }

        public IEnumerable<ApplicationUserr> GetAll()
        {
            var result = _userRepository.GetAll();
            return result;
        }
}
}
