using FluentValidation;
using PaymentHub.Core.Messages;

namespace PaymentHub.Application.Commands
{
    public class CreateTenantCommand : Command
    {
        //ctorp
        public string Name { get; }
        public string Email { get; }
        public string Cpnj { get; }

        public override bool IsValid()
        {
            ValidationResult = new CreateTenantValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CreateTenantValidation : AbstractValidator<CreateTenantCommand>
    {
        public CreateTenantValidation()
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

