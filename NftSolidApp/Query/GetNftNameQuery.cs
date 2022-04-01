using NftSolidApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Commands
{
    public class GetNftNameQuery:IQuery
    {

        public int NftId { get; set; }
        public string Name { get; set; }

        public GetNftNameQuery(int nftId, string name)
        {
            NftId = nftId;
            Name = name;
        }


    }
}
