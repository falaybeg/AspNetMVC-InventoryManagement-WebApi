using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NtierApp.Repository.Infrastucture.Contract
{
    public interface IBaseRespository<T>
    {
        T GetById(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);
        T Insert(T entity);
        void Update(T entity);
        void UpdateAll(IList<T> entities);
        void Delete(Expression<Func<T, bool>> filter);
        bool Exist(Expression<Func<T, bool>> filter);

    }
}
