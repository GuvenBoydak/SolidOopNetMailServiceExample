using NftSolidApp.Handler;
using NftSolidApp.Repositories;
using NftSolidApp.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Factories
{
    public static class NftBuyOnTheSalesListHandlerFactory
    {
        public static NftBuyOnTheSalesListHandler GetInstance()
        {
            NftRepository repository = NftRepositoryFactory.GetInstance();
            UserRepository userRepository = UserRepositoryFactory.GetInstance();
            NftBuyONTheSalesListEventSubscriber eventSubscriber = NftBuyONTheSalesListEventSubscriberFactory.GetInstance();
            return new NftBuyOnTheSalesListHandler(repository, userRepository,eventSubscriber);
        }
    }
}
