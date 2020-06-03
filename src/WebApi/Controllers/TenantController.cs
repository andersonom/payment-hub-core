using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentHub.Domain;

namespace PaymentHub.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly ILogger<TenantController> _logger;

        public TenantController(ILogger<TenantController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTenant(Tenant registeringTenant) => Ok();

    }
}
