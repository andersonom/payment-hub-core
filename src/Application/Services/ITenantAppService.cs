using System.Threading.Tasks;
using PaymentHub.Application.ViewModels;

namespace PaymentHub.Application.Events
{
    public interface ITenantAppService
    {
        Task<bool> Register(TenantViewModel registeringTenant);
    }
}