using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Quartz;
using Quartz.Spi;

namespace Arcomage.WebApi.Infrastructure
{
    public class AutofacJobFactory : IJobFactory
    {
        private readonly ConcurrentDictionary<IJob, ILifetimeScope> jobStorage = 
            new ConcurrentDictionary<IJob, ILifetimeScope>();

        private readonly ILifetimeScope lifetimeScope;

        public AutofacJobFactory(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var scope = lifetimeScope.BeginLifetimeScope();
            var job = (IJob)scope.Resolve(bundle.JobDetail.JobType);

            jobStorage[job] = scope;

            return job;
        }

        public void ReturnJob(IJob job)
        {
            if (jobStorage.TryRemove(job, out var scope))
                scope.Dispose();
        }
    }
}
