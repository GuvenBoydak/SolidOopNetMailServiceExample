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
    public class NftNotOnSalesListHandler : ICommandHandler<NftNotOnSalesListCommand, ResponceBase>
    {
        private readonly NftRepository _nftRepository;

        public NftNotOnSalesListHandler(NftRepository nftRepository)
        {
            _nftRepository = nftRepository;
        }

        public ResponceBase Execute(NftNotOnSalesListCommand command)
        {
            ResponceBase responce = new ResponceBase();

            Nft nft = new Nft(command.Price, command.NftId, command.UserId, command.State);
            Nft findNft = _nftRepository.Find(command.NftId);

            findNft.Price = command.Price;
            findNft.State = command.State;

            int result = _nftRepository.Save();

            if (result > 0)
            {
                responce.IsSuccesed = true;
                responce.Message = $"{nft.NftId} Numaralı nft Satış Listesinden Çıkarıldı.";
            }
            else
            {
                responce.IsSuccesed = false;
                responce.Message = "Listeleme başarısız.";
            }
            return responce;
        }
    }
}
