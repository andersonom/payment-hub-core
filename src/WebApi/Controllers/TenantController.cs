using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentHub.Application.Events;
using PaymentHub.Application.ViewModels;
using PaymentHub.Domain;

namespace PaymentHub.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly ILogger<TenantController> _logger;
        private readonly ITenantAppService _tenantAppService;

        public TenantController(ILogger<TenantController> logger, ITenantAppService tenantAppService)
        {
            _logger = logger;
            _tenantAppService = tenantAppService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTenant([FromBody]TenantViewModel tenant)
        {
            var res = await _tenantAppService.Register(tenant);

            //TODO Check res

            return Ok();
        }
    }
}
