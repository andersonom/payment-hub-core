using System;
using System.Threading.Tasks;
using AutoMapper;
using PaymentHub.Application.Commands;
using PaymentHub.Application.ViewModels;
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

        public TenantAppService(IMapper mapper, //TODO Mapper will be used on Query
                                IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<bool> Register(TenantViewModel tenant) //TODO  cancellationToken
        {
            return await _mediator.SendCommand(new RequestTenantCommand(tenant.Name,
                                                                        tenant.Email,
                                                                        tenant.Cpnj));
        }

    }
}