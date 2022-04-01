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

namespace NftSolidApp.Handler
{
    public class NftBuyNotOnSalesListHandler : ICommandHandler<NftBuyNotOnSalesListCommand, ResponceBase>
    {
        private readonly INftRepository _nftRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotification<NftBuyNotOnSalesListEvent> _notification;

        public NftBuyNotOnSalesListHandler(INftRepository nftRepository, IUserRepository userRepository, Interface.INotification<NftBuyNotOnSalesListEvent> notification)
        {
            _nftRepository = nftRepository;
            _userRepository = userRepository;
            _notification = notification;
        }

        public ResponceBase Execute(NftBuyNotOnSalesListCommand command)
        {
            ResponceBase responce = new ResponceBase();

            Nft nft = new Nft(command.Price, command.NftId, command.UserId, command.State);
            Nft findNft=_nftRepository.Find(command.NftId);

            User user = _userRepository.Find(command.UserId);

            decimal? oldPrice = findNft.Price;
            findNft.State = command.State;
            findNft.Price = command.Price;
            findNft.UserId = command.UserId;


            int result = _nftRepository.Save();

            if (result > 0)
            {
                responce.IsSuccesed = true;
                responce.Message = $"{findNft.NftId} numaralı {findNft.NftName} NFT'si {findNft.User.Name} {findNft.User.Surname} Tarafından alındı.";

                if (user!=null)
                {
                    NftBuyNotOnSalesListEvent @event = new NftBuyNotOnSalesListEvent(user.Email, command.NftId, findNft.NftName, oldPrice);
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
