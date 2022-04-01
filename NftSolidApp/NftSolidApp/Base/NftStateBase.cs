using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Base
{
    public abstract class NftStateBase
    {
        public int NftId { get; set; }
        public decimal? Price { get; set; }
        public int UserId { get; set; }
        public string State { get; set; }
    }
}
