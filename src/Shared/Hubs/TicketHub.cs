using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNet.SignalR;
using Shared.Notifications;

namespace Shared.Hubs
{
    public class TicketHub : Hub
    {
        private readonly IMediator mediator;

        public TicketHub(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task SubmitOrder(string theater, string movie, string time, int numberOfTickets)
        {
            var notification = new TicketOrderedNotification
            {
                Theater = theater,
                Movie = movie,
                Time = time,
                NumberOfTickets = numberOfTickets
            };

            await mediator.Publish(notification);

            //return messageSession.Send(new SubmitOrder() 
            //{
            //    Theater = Guid.Parse(theater),
            //    Movie = Guid.Parse(movie),
            //    Time = time,
            //    NumberOfTickets = numberOfTickets,
            //    UserId = Guid.Parse("218d92c4-9c42-4e61-80fa-198b22461f61") // For now, no other users allowed ;-)
            //});
        }
    }
}