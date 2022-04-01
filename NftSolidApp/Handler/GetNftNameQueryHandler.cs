using NftSolidApp.Commands;
using NftSolidApp.Entities;
using NftSolidApp.Interface;
using NftSolidApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Query
{
    public class GetNftNameQueryHandler : IQueryHandler<GetNftNameQuery, List<Nft>>
    {
        private readonly NftRepository _nftRepository;

        public GetNftNameQueryHandler(NftRepository nftRepository)
        {
            _nftRepository = nftRepository;
        }

        public List<Nft> Execute(GetNftNameQuery query)
        {
           List<Nft> nft = _nftRepository.Where(x=>x.NftName==query.Name).ToList();

           return nft;
        }
    }
}
