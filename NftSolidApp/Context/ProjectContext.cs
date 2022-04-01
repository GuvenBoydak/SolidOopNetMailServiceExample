using NftSolidApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Context
{
    public class ProjectContext:DbContext
    {
        public DbSet<Nft> Nfts { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
