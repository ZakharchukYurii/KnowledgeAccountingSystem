using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    class AreaRepository : IRepository<Area>
    {
        KnowledgeContext db;

        public AreaRepository(KnowledgeContext context)
        {
            this.db = context;
        }

        public Area Get(int id)
        {
            return db.Areas.Find(id);
        }

        public IEnumerable<Area> GetAll()
        {
            return db.Areas;
        }

        public IEnumerable<Area> Find(Func<Area, bool> predicate)
        {
            return db.Areas.Where(predicate).ToList();
        }

        public void Create(Area item)
        {
            if(item != null)
            {
                db.Areas.Add(item);
            }
        }

        public void Update(Area item)
        {
            if(item != null)
            {
                db.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Area area = db.Areas.Find(id);

            if(area != null)
            {
                db.Areas.Remove(area);
            }
        }
    }
}
