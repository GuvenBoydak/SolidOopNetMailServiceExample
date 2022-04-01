using NftSolidApp.Base;
using NftSolidApp.Commands;
using NftSolidApp.Entities;
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
        private readonly NftRepository _nftRepository;

        public NftBuyNotOnSalesListHandler(NftRepository nftRepository)
        {
            _nftRepository = nftRepository;
        }

        public ResponceBase Execute(NftBuyNotOnSalesListCommand command)
        {
            ResponceBase responce = new ResponceBase();

            Nft nft = new Nft(command.Price, command.NftId, command.UserId, command.State);
            _nftRepository.Find(command.NftId);

            int result = _nftRepository.Save();

            if (result > 0)
            {
                responce.IsSuccesed = true;
                responce.Message = $"{nft.NftId} numaralı {nft.NftName} NFT'si {nft.User.Name} {nft.User.Surname} Tarafından alındı.";
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
