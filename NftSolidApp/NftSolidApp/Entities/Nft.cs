using NftSolidApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Entities
{
    public class Nft:IEntity
    {       
        public int NftId { get; set; }
        public string NftName { get; set; }
        public string Protocol { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string Hat { get; set; }
        public string Background { get; set; }
        public decimal? Price { get; set; }
        public int UserId { get; set; }
        public string State { get; set; }

        public virtual User User { get; set; }

        public Nft(string nftName, string protocol, string description, string gender, string hat, string background, decimal? price, int userId, string state)
        {
            NftName = nftName;
            Protocol = protocol;
            Description = description;
            Gender = gender;
            Hat = hat;
            Background = background;
            Price = price;
            UserId = userId;
            State = state;
        }
        public Nft()
        {

        }

        public Nft(decimal? price, int nftId, int UserID, string state)
        {
            Price = price;
            NftId = nftId;
            UserId = UserID;
            State = state;
        }

        public override string ToString()
        {
            return $"{NftName}";
        }
    }
}
