using System;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.UoW
{
    public class KnowledgeUoW : IKnowledgeUnitOfWork
    {
        private KnowledgeContext db;
        private bool disposed = false;

        private KnowledgeRepository knowledgeRepository;
        private AreaRepository areaRepository;
        private UserRepository userRepository;
        private KnowledgeRateRepository rateRepository;

        public KnowledgeUoW(string connectionString)
        {
            db = new KnowledgeContext(connectionString);
        }

        public KnowledgeUoW(KnowledgeContext context)
        {
            this.db = context;
        }

        public IRepository<Knowledge> Knowledges
        {
            get
            {
                if(knowledgeRepository == null)
                {
                    knowledgeRepository = new KnowledgeRepository(db);
                }
                return knowledgeRepository;
            }
        }

        public IRepository<Area> Areas
        {
            get
            {
                if(areaRepository == null)
                {
                    areaRepository = new AreaRepository(db);
                }
                return areaRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if(userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }
                return userRepository;
            }
        }

        public IRepository<KnowledgeRate> Rates
        {
            get
            {
                if(rateRepository == null)
                {
                    rateRepository = new KnowledgeRateRepository(db);
                }
                return rateRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
