using NftSolidApp.Base;
using NftSolidApp.Commands;
using NftSolidApp.Entities;
using NftSolidApp.Events;
using NftSolidApp.Interface;
using NftSolidApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NftSolidApp.Handler
{
    public class NftBuyOnTheSalesListHandler : ICommandHandler<NftBuyOnTheSalesListCommand, ResponceBase>
    {
        private readonly NftRepository _nftRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotification<NftBuyOnTheSalesListEvent> _notification;

        public NftBuyOnTheSalesListHandler(NftRepository nftRepository, IUserRepository userRepository, INotification<NftBuyOnTheSalesListEvent> notification)
        {
            _nftRepository = nftRepository;
            _userRepository = userRepository;
            _notification = notification;
        }

        public ResponceBase Execute(NftBuyOnTheSalesListCommand command)
        {
            ResponceBase responce = new ResponceBase();

            Nft findnft = _nftRepository.Find(command.NftId);
            User user = _userRepository.Find(command.UserId);

            decimal? oldPrice = findnft.Price;
            command.Wallet -= (decimal)findnft.Price;           
            findnft.User.Wallet += (decimal)findnft.Price;
            findnft.UserId = command.UserId;

            user.Wallet = command.Wallet;

            findnft.Price = command.Price;
            findnft.State = command.State;

            int result = _nftRepository.Save();
            int result1 = _userRepository.Save();


            if (result1>0)
            {

            }

            if (result > 0)
            {
                responce.IsSuccesed = true;
                responce.Message = $"{findnft.NftId} numaralı {findnft.NftName} NFT'si {user.Name} {user.Surname} Tarafından alındı.";

                if (user != null)
                {
                    NftBuyOnTheSalesListEvent @event = new NftBuyOnTheSalesListEvent(user.Email, findnft.NftId, findnft.NftName, oldPrice);
                    _notification.Notify(@event);
                    responce.Message = $"{_notification.NotificationMessage}";
                }
            }
            else
            {
                responce.IsSuccesed = false;
                responce.Message = "Satın alma işlemi Başarısız!!!";
            }
            return responce;

        }
    }
}
