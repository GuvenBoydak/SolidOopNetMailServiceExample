using NftSolidApp.Service;
using NftSolidApp.Subscribers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Factories
{
    public static class NftBuyEventSubscriberFactory
    {
        public static NftBuyNotOnSalesListEventSubscriber GetInstance()
        {
            NetMailService netMail = NetMailServiceFactory.GetInstance();

            return new NftBuyNotOnSalesListEventSubscriber(netMail);
        }
    }
}
