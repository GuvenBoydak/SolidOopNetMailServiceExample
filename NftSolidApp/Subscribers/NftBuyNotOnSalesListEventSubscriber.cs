using NftSolidApp.Events;
using NftSolidApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Subscribers
{
    public class NftBuyNotOnSalesListEventSubscriber : INotification<NftBuyNotOnSalesListEvent>
    {
        private readonly IMailService _mailService;

        public NftBuyNotOnSalesListEventSubscriber(IMailService mailService)
        {
            _mailService = mailService;
        }

        public string NotificationMessage { get;  set; }

        public void Notify(NftBuyNotOnSalesListEvent @event)
        {
            if (_mailService!=null)
            {
                List<string> email = new List<string>();
                email.Add(@event.Email);

                bool result = _mailService.SendMail(
                    @event.MessageTitle,
                    @event.Message,
                    email
                    );

                if (result==true)
                {
                    NotificationMessage = "EPosta Başarılı bir Şekilde Satıcıya gönderildi.";
                }
                else
                {
                    NotificationMessage = "EPosta Satıcıya Göderilemedi Başarısız!!!";
                }
            }
        }
    }
}
