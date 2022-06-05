using FluentValidation;
using test_CSharp.Models;
using test_CSharp.Models.DTO;

namespace test_CSharp.Validators
{
    public class CandidateExperienceValidator : AbstractValidator<CandidateExperienceDTO>
    {
        public CandidateExperienceValidator()
        {
            RuleFor(e => e.IdCandidate)
                .NotEmpty()
                    .WithMessage("Candidate ID field must not not be empty")
                .NotEqual(0)
                    .WithMessage("Insert a Valid Candidate");

            RuleFor(e => e.Company)
                .NotEmpty()
                    .WithMessage("Company field must not not be empty")
                .MaximumLength(100)
                   .WithMessage("Company lenght must me less than 100");

            RuleFor(e => e.Job)
                 .NotEmpty()
                    .WithMessage("Job field must not not be empty")
                .MaximumLength(100)
                   .WithMessage("Job lenght must me less than 100");

            RuleFor(e => e.Description)
                .NotEmpty()
                    .WithMessage("Description field must not not be empty")
                .MaximumLength(100)
                   .WithMessage("Description lenght must me less than 4000");

            RuleFor(e => e.Salary)
                .NotNull()
                    .WithMessage("Salary must not be null")
                .GreaterThan(0)
                    .WithMessage("Salary must be greater than 0");
        }
    }
}
