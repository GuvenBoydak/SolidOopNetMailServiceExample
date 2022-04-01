using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Interface
{
    public interface IQueryHandler<TQuery,T> where T:class where TQuery:class,IQuery
    {
        T Execute(TQuery query);
    }
}
