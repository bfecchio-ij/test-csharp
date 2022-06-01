using FluentValidation;
using test_CSharp.Models;

namespace test_CSharp.Validators
{
    public class AddCandidateValidator : AbstractValidator<Candidate>
    {
        public AddCandidateValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                    .WithMessage("Candidate name is required")
                .MaximumLength(50)
                    .WithMessage("Name length must be less than 50");

            RuleFor(m => m.Surname)
                .NotEmpty()
                    .WithMessage("Candidate surname is required")
                .MaximumLength(150)
                    .WithMessage("Surname length must be less than 150");

            RuleFor(m => m.Email)
                .NotEmpty()
                    .WithMessage("Candidate email is required")
                .MaximumLength(250)
                    .WithMessage("Email length must be less than 250");

        }
    }
}
