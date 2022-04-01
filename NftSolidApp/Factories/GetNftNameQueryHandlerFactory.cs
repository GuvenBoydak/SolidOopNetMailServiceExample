using NftSolidApp.Query;
using NftSolidApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Factories
{
    public static class GetNftNameQueryHandlerFactory
    {
        public static GetNftNameQueryHandler GetInstance()
        {
            NftRepository repository = NftRepositoryFactory.GetInstance();
            return new GetNftNameQueryHandler(repository);
        }
    }
}
