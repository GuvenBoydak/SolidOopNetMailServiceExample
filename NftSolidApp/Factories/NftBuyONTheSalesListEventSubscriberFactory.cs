using NftSolidApp.Service;
using NftSolidApp.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Factories
{
    public static class NftBuyONTheSalesListEventSubscriberFactory
    {
        public static NftBuyONTheSalesListEventSubscriber GetInstance()
        {
            NetMailService netMailService = NetMailServiceFactory.GetInstance();
            return new NftBuyONTheSalesListEventSubscriber(netMailService);
        }
    }
}
