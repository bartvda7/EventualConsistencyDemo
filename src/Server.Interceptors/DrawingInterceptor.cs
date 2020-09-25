using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNet.SignalR;
using NServiceBus;
using Shared.Hubs;
using Shared.Notifications;

namespace Server.Interceptors
{
    public class DrawingInterceptor : INotificationHandler<TicketOrderedNotification>
    {
        private readonly IHubContext<TicketHub> ticketHubContext;

        public DrawingInterceptor(IHubContext<TicketHub> ticketHubContext)
        {
            this.ticketHubContext = ticketHubContext;
        }

        public Task Handle(TicketOrderedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
