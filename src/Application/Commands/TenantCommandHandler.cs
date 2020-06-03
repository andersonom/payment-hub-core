using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentHub.Core.Communication.Mediator;
using PaymentHub.Core.Messages;
using PaymentHub.Core.Messages.CommonMessages;

namespace PaymentHub.Application.Commands
{
    public class TenantCommandHandler : IRequestHandler<CreateTenantCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public TenantCommandHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }
        public async Task<bool> Handle(CreateTenantCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            //TODO Add Tenent at repository

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

