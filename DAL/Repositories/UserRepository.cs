using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        KnowledgeContext db;

        public UserRepository(KnowledgeContext context)
        {
            db = context;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Create(User item)
        {
            if(item != null)
            {
                db.Users.Add(item);
            }
        }

        public void Update(User item)
        {
            if(item != null)
            {
                db.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);

            if(user != null)
            {
                db.Users.Remove(user);
            }
        }
    }
}
