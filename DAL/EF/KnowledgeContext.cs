using DAL.Entities;
using System.Data.Entity;

namespace DAL.EF
{
    public class KnowledgeContext : DbContext
    {
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<KnowledgeRate> Rates { get; set; }

        static KnowledgeContext()
        {
            Database.SetInitializer<KnowledgeContext>(new DbInitializer());
        }

        public KnowledgeContext(string connectionString)
            : base(connectionString)
        {
            // When ADO.NET don't create SQL Client
            //var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
