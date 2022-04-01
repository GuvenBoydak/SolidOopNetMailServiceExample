using NftSolidApp.Handler;
using NftSolidApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Factories
{
    public static class NftOnTheSalesListHandlerFactory
    {
        public static NftOnTheSalesListHandler GetInstance()
        {
            NftRepository nftRepository = NftRepositoryFactory.GetInstance();
            return new NftOnTheSalesListHandler(nftRepository);
        }
    }
}
