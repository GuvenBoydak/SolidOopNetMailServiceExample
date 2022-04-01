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
    public class NftCreateHandler: ICommandHandler<NftCreateCommand, ResponceBase>
    {
        private readonly INftRepository _nftRepository;

        public NftCreateHandler(INftRepository nftRepository)
        {
            _nftRepository = nftRepository;
        }

        public ResponceBase Execute(NftCreateCommand command)
        {
            ResponceBase responce = new ResponceBase();

            Nft nft = new Nft(command.NftName, command.Protocol, command.Description, command.Gender, command.Hat, command.Background, command.Price, command.UserId,command.State);

            _nftRepository.Add(nft);

            int result = _nftRepository.Save();

            if (result>0)
            {
                responce.IsSuccesed = true;
                responce.Message = "Başarıyla Nft Eklendi.";
            }
            else
            {
                responce.IsSuccesed = true;
                responce.Message = "Nft Ekleme Başarısız!";
            }
            return responce;
        }
    }
}
