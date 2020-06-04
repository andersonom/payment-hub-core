using FluentValidation;
using PaymentHub.Core.Messages;

namespace PaymentHub.Application.Commands
{
    public class RequestTenantCommand : Command
    {
        public RequestTenantCommand(string name, string email, string cnpj)
        {
            Name = name;
            Email = email;
            Cpnj = cnpj;
        }

        public string Name { get; }
        public string Email { get; }
        public string Cpnj { get; }

        public override bool IsValid()
        {
            ValidationResult = new RequestTenantValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    
    public class RequestTenantValidation : AbstractValidator<RequestTenantCommand>
    {//TODO Move
        public RequestTenantValidation()
        {
            RuleFor(i => i.Name)
            .MinimumLength(3)
                .MaximumLength(50)
                    .NotEmpty();

            RuleFor(i => i.Email)
            .MinimumLength(4)
                .MaximumLength(50)
                    .EmailAddress()
                        .NotEmpty();

            RuleFor(i => i.Cpnj)
             .Length(14)//TODO Regex
                .NotEmpty();
        }
    }
}

