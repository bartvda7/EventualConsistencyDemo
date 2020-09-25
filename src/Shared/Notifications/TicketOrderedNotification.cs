using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shared.Notifications
{
    public class TicketOrderedNotification : INotification
    {
        public string Theater { get; set; }
        public string Movie { get; set; }
        public string Time { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
