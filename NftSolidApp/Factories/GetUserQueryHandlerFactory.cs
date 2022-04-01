using NftSolidApp.Handler;
using NftSolidApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Factories
{
    public static class GetUserQueryHandlerFactory
    {
        public static GetUserQueryHandler GetInstance()
        {
            NftRepository nftRepository = NftRepositoryFactory.GetInstance();
            return new GetUserQueryHandler(nftRepository);
        }
    }
}
