using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Notifications;
using Hangfire;
using MediatR;

namespace Arcomage.Network.Hangfire.NotificationHandlers
{
    public class CancelGameNotificationHandler : INotificationHandler<CancelGameNotification>
    {
        public void Handle(CancelGameNotification notification)
        {
            BackgroundJob.Delete(notification.GameContext.JobId);
        }
    }
}
