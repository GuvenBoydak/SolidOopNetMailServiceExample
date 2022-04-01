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
    public class UserRepository:IUserRepository
    {
        private readonly ProjectContext _db;

        public UserRepository(ProjectContext db)
        {
            _db = db;
        }

         public void Add(User entity)
        {
            _db.Users.Add(entity);
        }

        public void Delete(int id)
        {
            User user = _db.Users.Find(id);
            _db.Users.Remove(user);
        }

        public void Update(User entity)
        {
            _db.Users.Attach(entity);

            DbEntityEntry entry = _db.Entry(entity);

            foreach (var item in entry.OriginalValues.PropertyNames)
            {
                var orginal = entry.GetDatabaseValues().GetValue<object>(item);
                var current = entry.CurrentValues.GetValue<object>(item);

                if (!object.Equals(orginal, current))
                {
                    entry.Property(item).IsModified = true;
                }
            }
        }

        public List<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public List<User> Where(Expression<Func<User, bool>> expression)
        {
            return _db.Users.Where(expression).ToList();
        }

        public int Save()
        {
            return _db.SaveChanges();
        }

        public User Find(int id)
        {
            return _db.Users.Find(id);
        }
    }
}
