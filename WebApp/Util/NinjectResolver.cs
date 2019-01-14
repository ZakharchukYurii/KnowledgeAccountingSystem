using BLL.Interfaces;
using BLL.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApp.Utils
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IAreaService>().To<AreaService>();
            kernel.Bind<IKnowledgeService>().To<KnowledgeService>();
            kernel.Bind<IMakeSelectionService>().To<MakeSelectionService>();
            kernel.Bind<IRateService>().To<RateService>();
            kernel.Bind<IUserService>().To<UserService>();
        }
    }
}