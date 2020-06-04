using System.Threading;
using System.Threading.Tasks;
using MediatR;
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
            if (!ValidateCommand(message))
            {
                //TODO Call the event to call the command
                await _mediatorHandler.SendCommand(new RegisterTenantCommand(message.Name,
                                                                             message.Email,
                                                                             message.Cpnj));
                return false;
            }
                //TODO Call the event to call the command
                await _mediatorHandler.SendCommand(new RejectTenantRegisterCommand(message.Name,
                                                                                   message.Email,
                                                                                   message.Cpnj));
            return true;
        }

        public async Task<bool> Handle(RegisterTenantCommand message, CancellationToken cancellationToken)
        {

            //TODO CreateTenant.CreateEvent

            //TODO Add Tenent at repository

            return true;
        }

        public async Task<bool> Handle(RejectTenantRegisterCommand message, CancellationToken cancellationToken)
        { 
            //TODO CreateTenant.CreateEvent
            return true;
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

