using NftSolidApp.Context;
using NftSolidApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NftSolidApp.Repositories
{
    public class NftRepository : INftRepository
    {
        private readonly ProjectContext _db;

        public NftRepository(ProjectContext db)
        {
            _db = db;
        }

        public void Add(Nft entity)
        {
            _db.Nfts.Add(entity);
        }

        public void Delete(int id)
        {
            Nft nft = _db.Nfts.Find(id);
            _db.Nfts.Remove(nft);
        }
       

        public Nft Find(int id)
        {
            return _db.Nfts.Find(id);
        }

        public List<Nft> GetAll()
        {
            return _db.Nfts.ToList();
        }

        public int Save()
        {
            return _db.SaveChanges();
        }

        public void Update(Nft entity)
        {
            _db.Nfts.Attach(entity);

            DbEntityEntry entry = _db.Entry(entity);

            foreach (var item in entry.OriginalValues.PropertyNames)
            {
                var orginal = entry.GetDatabaseValues().GetValue<object>(item);
                var current = entry.CurrentValues.GetValue<object>(item);

                if (!object.Equals(orginal,current))
                {
                    entry.Property(item).IsModified = true;
                }
            }
        }

        public List<Nft> Where(Expression<Func<Nft, bool>> expression)
        {
            return _db.Nfts.Where(expression).ToList();
        }
    }
}
