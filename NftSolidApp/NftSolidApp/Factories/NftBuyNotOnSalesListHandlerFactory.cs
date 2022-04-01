using NftSolidApp.Handler;
using NftSolidApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Factories
{
    public static class NftBuyNotOnSalesListHandlerFactory
    {

        public static NftBuyNotOnSalesListHandler GetInstance() 
        {
            NftRepository repository = NftRepositoryFactory.GetInstance();
            return new NftBuyNotOnSalesListHandler(repository);
        }
    }
}
