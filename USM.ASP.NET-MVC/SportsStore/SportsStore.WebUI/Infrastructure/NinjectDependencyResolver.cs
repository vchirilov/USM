using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }

        public IKernel Kernel { get => kernel; set => kernel = value; }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
        }
    }
}