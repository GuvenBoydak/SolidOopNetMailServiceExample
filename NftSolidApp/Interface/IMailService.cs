using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Interface
{
    public interface IMailService
    {
        bool SendMail(string subject,string body,List<string> to);
    }
}
