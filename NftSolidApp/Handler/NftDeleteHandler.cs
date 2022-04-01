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
    public class NftDeleteHandler : ICommandHandler<NftDeleteCommand, ResponceBase>
    {
        private readonly INftRepository _nftRepository;

        public NftDeleteHandler(INftRepository nftRepository)
        {
            _nftRepository = nftRepository;
        }

        public ResponceBase Execute(NftDeleteCommand command)
        {
            ResponceBase responce = new ResponceBase();

            _nftRepository.Delete(command.NftId);


            int result = _nftRepository.Save();
            if (result>0)
            {
                responce.IsSuccesed = true;
                responce.Message = $"{command.NftId} numaralı nft Silme İşlemi Başarılı";
            }
            else
            {
                responce.IsSuccesed = false;
                responce.Message = $"{command.NftId} numaralı nft Silme İşlemi Başarısız!!!";
            }
            return responce;

        }
    }
}
