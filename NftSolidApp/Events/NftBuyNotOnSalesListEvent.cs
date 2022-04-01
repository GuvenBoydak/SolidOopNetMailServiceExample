using NftSolidApp.Base;
using NftSolidApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Events
{
    public class NftBuyNotOnSalesListEvent: IEvent
    {
        public string Email { get; set; }
        public string Message { get; set; }
        public string MessageTitle { get; set; }
        public int NftId { get; set; }
        public string NftName { get; set; }
        public decimal? Price { get; set; }

        public NftBuyNotOnSalesListEvent(string email,int NftId,string NftName,decimal? Price)
        {
            Email = email;
            Message = $"{NftId} numaralı {NftName} adlı Nft'niz {Price} Eth'ye satın Alınıldı.";
            MessageTitle = $"Tebrikler {NftName} Ntf'si Listeden kaldırıldı. ";
        }
    }
}
