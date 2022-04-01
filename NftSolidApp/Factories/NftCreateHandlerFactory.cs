using NftSolidApp.Handler;
using NftSolidApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Factories
{
    public static class NftCreateHandlerFactory
    {
        public static NftCreateHandler GetInstance()
        {
            NftRepository repository = NftRepositoryFactory.GetInstance();
            return new NftCreateHandler(repository);
        }
    }
}
