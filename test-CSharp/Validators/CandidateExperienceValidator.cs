using FluentValidation;
using test_CSharp.Models;

namespace test_CSharp.Validators
{
    public class CandidateExperienceValidator : AbstractValidator<CandidateExperience>
    {
        public CandidateExperienceValidator()
        {
            RuleFor(e => e.Company)
                .Empty()
                    .WithMessage("Company field must not not be empty")
                .MaximumLength(100)
                   .WithMessage("Company lenght must me less than 100");

            RuleFor(e => e.Job)
                 .Empty()
                    .WithMessage("Job field must not not be empty")
                .MaximumLength(100)
                   .WithMessage("Job lenght must me less than 100");

            RuleFor(e => e.Description)
                .Empty()
                    .WithMessage("Description field must not not be empty")
                .MaximumLength(100)
                   .WithMessage("Description lenght must me less than 4000");

            RuleFor(e => e.Salary)
                .Null()
                    .WithMessage("Salary must not be null")
                .LessThanOrEqualTo(0)
                    .WithMessage("Salary must not be less than 0");
        }
    }
}
