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
    
    public class NftOnTheSalesListCommand : NftStateBase,ICommand
    {      
        public NftOnTheSalesListCommand(int userId, decimal? price, int nftId, string state)
        {
            UserId = userId;
            Price = price;
            NftId = nftId;
            State = NftState.OnTheSalesList.ToString();
        }
    }
}
