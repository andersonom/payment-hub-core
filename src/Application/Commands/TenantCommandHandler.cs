using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentHub.Application.Events;
using PaymentHub.Core.Communication.Mediator;
using PaymentHub.Core.Messages;
using PaymentHub.Core.Messages.CommonMessages;

namespace PaymentHub.Application.Commands
{
  public class TenantCommandHandler :
      IRequestHandler<RequestTenantCommand, bool>,
      IRequestHandler<RegisterTenantCommand, bool>,
      IRequestHandler<RejectTenantRegisterCommand, bool>
  {
    private readonly IMediatorHandler _mediatorHandler;

    public TenantCommandHandler(IMediatorHandler mediatorHandler)
    {
      _mediatorHandler = mediatorHandler;
    }
    public async Task<bool> Handle(RequestTenantCommand message, CancellationToken cancellationToken)
    {
      await _mediatorHandler.PublishEvent(new TenantRequestedEvent(message.Name,
                                                                   message.Email,
                                                                   message.Cpnj));

      if (!ValidateCommand(message))
      {

        await _mediatorHandler.SendCommand(new RejectTenantRegisterCommand(message.Name,
                                                                           message.Email,
                                                                           message.Cpnj));

        return false;//TODO Comando executado com sucesso, deveria ser true ?
      }

      await _mediatorHandler.SendCommand(new RegisterTenantCommand(message.Name,
                                                                   message.Email,
                                                                   message.Cpnj));

      return true;
    }

    public async Task<bool> Handle(RegisterTenantCommand message, CancellationToken cancellationToken)
    {

      //TODO Aggregate logic .. + mover evento para CreateTenant.CreateEvent ?

      //TODO Add Tenent at repository

      //TODO Add logic to call RAC
      await _mediatorHandler.PublishEvent(new TenantRegisteredEvent(message.Name,
                                                                    message.Email,
                                                                    message.Cpnj));

      return true;
    }

    public async Task<bool> Handle(RejectTenantRegisterCommand message, CancellationToken cancellationToken)
    {
      //TODO Add logic to call RAC
      return await _mediatorHandler.SendCommand(new RejectTenantRegisterCommand(message.Name,
                                                                         message.Email,
                                                                         message.Cpnj));
    }

    private bool ValidateCommand(Command message)
    {
      if (message.IsValid()) return true;

      foreach (var error in message.ValidationResult.Errors)
      {
        _mediatorHandler.PublishNotification(new DomainNotification(message.MessageType, error.ErrorMessage));
      }

      return false;
    }
  }
}

