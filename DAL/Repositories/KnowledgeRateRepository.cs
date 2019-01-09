using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class KnowledgeRateRepository : IRepository<KnowledgeRate>
    {
        KnowledgeContext db;

        public KnowledgeRateRepository(KnowledgeContext context)
        {
            this.db = context;
        }

        public KnowledgeRate Get(int id)
        {
            return db.Rates.Find(id);
        }

        public IEnumerable<KnowledgeRate> GetAll()
        {
            return db.Rates;
        }

        public IEnumerable<KnowledgeRate> Find(Func<KnowledgeRate, bool> predicate)
        {
            return db.Rates.
                Include(r => r.User).
                Include(r => r.Knowledge).
                Where(predicate).ToList();
        }

        public void Create(KnowledgeRate item)
        {
            db.Rates.Add(item);
        }

        public void Update(KnowledgeRate item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            KnowledgeRate rate = db.Rates.Find(id);

            if(rate != null)
            {
                db.Rates.Remove(rate);
            }
        }
    }
}
