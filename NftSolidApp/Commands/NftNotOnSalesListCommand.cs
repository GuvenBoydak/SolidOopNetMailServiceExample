using NftSolidApp.Base;
using NftSolidApp.Enums;
using NftSolidApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Commands
{
    public class NftNotOnSalesListCommand:NftStateBase,ICommand
    {
        public NftNotOnSalesListCommand(int userId, decimal? price, int nftId, string state)
        {
            UserId = userId;
            Price = null;
            NftId = nftId;
            State = NftState.NotOnSalesList.ToString();
        }
    }
}
