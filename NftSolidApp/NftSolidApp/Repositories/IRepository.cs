using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll();
        List<T> Where(Expression<Func<T, bool>> expression);
        int Save();
        T Find(int id);

    }
}
