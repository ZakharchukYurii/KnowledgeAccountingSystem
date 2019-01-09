using DAL.Interfaces;
using DAL.UoW;
using Ninject.Modules;

namespace BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IKnowledgeUnitOfWork>().To<KnowledgeUoW>().WithConstructorArgument(connectionString);
        }
    }
}