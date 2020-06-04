using FluentValidation;
using PaymentHub.Core.Messages;

namespace PaymentHub.Application.Commands
{
  public class RegisterTenantCommand : Command
  {
    public RegisterTenantCommand(string name, string email, string cnpj)
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