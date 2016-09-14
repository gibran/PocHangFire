using Hangfire;
using Microsoft.Owin;
using Owin;
using Poc_HangFire.Models;
using Poc_HangFire.Repositories;
using SimpleInjector;
using System;

[assembly: OwinStartup(typeof(Poc_HangFire.Startup))]

namespace Poc_HangFire
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var connectionString = @"DefaultConnection";
            GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);

            var container = new Container();
            container.Register<IJob, MyJob>();
            container.Register<IPocRepository, PocRepository>();
            container.Verify();

            GlobalConfiguration.Configuration.UseActivator(new ContainerJobActivator(container));

            app.UseHangfireDashboard();
            app.UseHangfireServer();

        }
    }

    public class ContainerJobActivator : JobActivator
    {
        private Container _container;

        public ContainerJobActivator(Container container)
        {
            _container = container;
        }

        public override object ActivateJob(Type type)
        {
            return _container.GetInstance(type);
            //return _container.Resolve(type);
        }
    }

}