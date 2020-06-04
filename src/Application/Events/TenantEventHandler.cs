using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentHub.Application.Events;
using PaymentHub.Core.Communication.Mediator;

namespace NerdStore.Vendas.Application.Events
{
  public class TenantEventHandler :
      INotificationHandler<TenantRequestedEvent>,
      INotificationHandler<TenantRegisteredEvent>,
      INotificationHandler<TenantRegisterRejectedEvent>
  {
    private readonly IMediatorHandler _mediatorHandler;

    public TenantEventHandler(IMediatorHandler mediatorHandler)
    {
      _mediatorHandler = mediatorHandler;
    }

    public Task Handle(TenantRequestedEvent notification, CancellationToken cancellationToken)
    {
      return Task.CompletedTask;
    }

    public Task Handle(TenantRegisteredEvent message, CancellationToken cancellationToken)
    {
      return Task.CompletedTask;
    }

    public Task Handle(TenantRegisterRejectedEvent message, CancellationToken cancellationToken)
    {
      return Task.CompletedTask;
    }
  }
}