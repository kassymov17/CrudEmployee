using System;
using System.Web.Mvc;
using System.Collections.Generic;
using CrudEmployee.Domain.Abstract;
using CrudEmployee.Domain.Concrete;
using Ninject;
using Ninject.Web.Common;
using Ninject.Extensions.Conventions;

namespace CrudEmployee.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
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
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind(x => x.FromAssembliesMatching("*").SelectAllClasses().Excluding<UnitOfWork>().BindDefaultInterface());
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            
        }
    }
}