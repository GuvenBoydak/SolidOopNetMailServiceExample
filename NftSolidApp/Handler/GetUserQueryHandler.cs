using NftSolidApp.Entities;
using NftSolidApp.Interface;
using NftSolidApp.Query;
using NftSolidApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Handler
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, List<Nft>>
    {
        private readonly INftRepository _nftRepository;
     
        public GetUserQueryHandler(INftRepository nftRepository)
        {
            _nftRepository = nftRepository;
        }

        public List<Nft> Execute(GetUserQuery query)
        {
            List<Nft> userList = _nftRepository.Where(x=>x.UserId==query.UserId).ToList();

            return userList;
        }
    }
}
