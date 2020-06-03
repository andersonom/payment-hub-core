using System;
using System.Threading.Tasks;
using AutoMapper;

namespace PaymentHub.Application.Events
{
    public class TenantAppService : ITenantAppService
    {
        private readonly IMapper mapper;

        //Command
        //Query

        public TenantAppService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async Task<bool> Register() //TODO viewModel,// cancellationToken
        {
            throw new NotImplementedException();
        }

    }
}