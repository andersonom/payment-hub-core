using PaymentHub.Core.Messages;

namespace PaymentHub.Application.Events
{
  public class TenantRegisteredEvent : Event
  {
    public TenantRegisteredEvent(string name, string email, string cnpj)
    {
      Name = name;
      Email = email;
      Cpnj = cnpj;
    }

    public string Name { get; }
    public string Email { get; }
    public string Cpnj { get; }
  }
}