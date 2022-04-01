using NftSolidApp.Events;
using NftSolidApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Subscribers
{
    public class NftBuyONTheSalesListEventSubscriber : INotification<NftBuyOnTheSalesListEvent>
    {
        private readonly IMailService _mailService;

        public NftBuyONTheSalesListEventSubscriber(IMailService mailService)
        {
            _mailService = mailService;
        }

        public string NotificationMessage { get; set; }

        public void Notify(NftBuyOnTheSalesListEvent @event)
        {
            if (_mailService!=null)
            {
                List<string> mail = new List<string>();
                mail.Add(@event.Email);

                bool result = _mailService.SendMail(@event.MessageTitle,@event.Message,mail);

                if(result == true)
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
