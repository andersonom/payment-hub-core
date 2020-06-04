using PaymentHub.Core.DomainObjects;

namespace PaymentHub.Domain
{
  public class Tenant : Entity, IAggregateRoot
  {
    public Tenant(string name, string email, string cpnj)
    {
      Name = name;
      Email = email;
      Cpnj = Cpnj;
    }
    
    public string Name { get; }
    public string Email { get; }
    public string Cpnj { get; }
  }
}