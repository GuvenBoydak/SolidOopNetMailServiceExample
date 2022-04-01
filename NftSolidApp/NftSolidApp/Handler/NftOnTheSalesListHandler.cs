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
    public class NftOnTheSalesListHandler : ICommandHandler<NftOnTheSalesListCommand, ResponceBase>
    {
        private readonly NftRepository _nftRepository;

        public NftOnTheSalesListHandler(NftRepository nftRepository)
        {
            _nftRepository = nftRepository;
        }

        public ResponceBase Execute(NftOnTheSalesListCommand command)
        {
            ResponceBase responce = new ResponceBase();

            Nft nft = new Nft(command.Price,command.NftId,command.UserId,command.State);

            Nft findNft=_nftRepository.Find(nft.NftId);
            findNft.Price = nft.Price;
            findNft.State = nft.State;

            int result = _nftRepository.Save();

            if (result>0)
            {
                responce.IsSuccesed = true;
                responce.Message = $"{nft.NftId} Numaralı nft Satış Listesine alındı.";
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
