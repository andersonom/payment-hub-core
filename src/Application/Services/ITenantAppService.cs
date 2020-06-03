using System.Threading.Tasks;

namespace PaymentHub.Application.Events
{
    public interface ITenantAppService
    {
        Task<bool> Register();
    }
}