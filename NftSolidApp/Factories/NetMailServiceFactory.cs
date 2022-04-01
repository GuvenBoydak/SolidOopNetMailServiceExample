using NftSolidApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Factories
{
    public static class NetMailServiceFactory
    {
        public static NetMailService GetInstance()
        {
            return new NetMailService();
        }
    }
}
