using NftSolidApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Query
{
    public class GetNftStateQuery:IQuery
    {
        public GetNftStateQuery( string state)
        {

            State = state;
        }


        public string State { get; set; }
    }
}
