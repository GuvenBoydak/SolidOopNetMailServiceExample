using NftSolidApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Entities
{
    public class User:IEntity
    {
    

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public decimal Wallet { get; set; }

        public virtual ICollection<Nft> Nfts { get; set; }



        public User(string name, string surname, string email, decimal wallet)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Wallet = wallet;
        }
        public User()
        {

        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
