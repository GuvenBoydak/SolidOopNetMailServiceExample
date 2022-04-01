using NftSolidApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Commands
{
    public class NftDeleteCommand:ICommand
    {
        public int NftId { get; set; }

        public NftDeleteCommand(int nftId)
        {
            NftId = nftId;
        }
    }
}
