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
    public class GetNftStateQueryHandler : IQueryHandler<GetNftStateQuery, List<Nft>>
    {
        private readonly INftRepository _nftRepository;

        public GetNftStateQueryHandler(INftRepository nftRepository)
        {
            _nftRepository = nftRepository;
        }

        public List<Nft> Execute(GetNftStateQuery query)
        {
            List<Nft> nft = _nftRepository.Where(x=>x.State==query.State).ToList();
            return nft;
        }
    }
}
