using System;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IKnowledgeUnitOfWork : IDisposable
    {
        IRepository<Knowledge> Knowledges { get; }
        IRepository<Area> Areas { get; }
        IRepository<User> Users { get; }
        IRepository<KnowledgeRate> Rates { get; }
        void Save();
    }
}
