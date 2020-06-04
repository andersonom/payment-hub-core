using System;
using System.Threading.Tasks;
using AutoMapper;
using PaymentHub.Application.Commands;
using PaymentHub.Core.Communication.Mediator;
using PaymentHub.Domain;

namespace PaymentHub.Application.Events
{
    public class TenantAppService : ITenantAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        //Command
        //Query

        public TenantAppService(IMapper mapper, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<bool> Register(Tenant tenant) //TODO viewModel,// cancellationToken
        {
            return await _mediator.SendCommand(new RequestTenantCommand(tenant.Name,
                                                                        tenant.Email,
                                                                        tenant.Cpnj));
        }

    }
}