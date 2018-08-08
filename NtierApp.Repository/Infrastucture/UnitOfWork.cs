using NtierApp.Repository.Context;
using NtierApp.Repository.Infrastucture.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtierApp.Repository.Infrastucture
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryDbContext _dbContext;

        public UnitOfWork()
        {
            _dbContext = new InventoryDbContext();
        }

        public DbContext Db
        { get { return _dbContext; } }

        public void Dispose()
        {
        }
    }
}
