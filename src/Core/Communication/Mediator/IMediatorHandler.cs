using System.Threading.Tasks;
using PaymentHub.Core.Messages;
using PaymentHub.Core.Messages.CommonMessages; 

namespace PaymentHub.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T myEvent) where T : Event;
        Task<bool> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
        Task PublishDomainEvent<T>(T notification) where T : DomainEvent;
    }
}