using System.Threading.Tasks;
using PaymentHub.Domain;

namespace PaymentHub.Application.Events
{
    public interface ITenantAppService
    {
        Task<bool> Register(Tenant registeringTenant);
    }
}