using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Notifications;
using MediatR;
using Quartz;

namespace Arcomage.Network.Quartz.NotificationHandlers
{
    public class CancelGameNotificationHandler : IAsyncNotificationHandler<CancelGameNotification>
    {
        private readonly IScheduler scheduler;

        public CancelGameNotificationHandler(IScheduler scheduler)
        {
            this.scheduler = scheduler;
        }

        public Task Handle(CancelGameNotification notification)
        {
            return scheduler.Interrupt(QuartzKeyGenerator.JobForPlayGame(notification.GameContext));
        }
    }
}
