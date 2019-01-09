using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class KnowledgeRepository : IRepository<Knowledge>
    {
        KnowledgeContext db;

        public KnowledgeRepository(KnowledgeContext context)
        {
            this.db = context;
        }

        public Knowledge Get(int id)
        {
            return db.Knowledges.Find(id);
        }

        public IEnumerable<Knowledge> GetAll()
        {
            return db.Knowledges.ToList();
        }

        public IEnumerable<Knowledge> Find(Func<Knowledge, bool> predicate)
        {
            return db.Knowledges.Include(k => k.Area).Where(predicate).ToList();
        }

        public void Create(Knowledge item)
        {
            db.Knowledges.Add(item);
        }

        public void Update(Knowledge item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Knowledge knowledge = db.Knowledges.Find(id);

            if(knowledge != null)
            {
                db.Knowledges.Remove(knowledge);
            }
        }
    }
}
