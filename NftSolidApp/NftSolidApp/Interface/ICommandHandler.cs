using NftSolidApp.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Interface
{
   public interface ICommandHandler<TCommand,TResponce> where TCommand:ICommand where TResponce:ResponceBase
    {
        TResponce Execute(TCommand command);
    }
}
