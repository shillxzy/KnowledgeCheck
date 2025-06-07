using FluentValidation;
using KnowledgeCheck.BLL.DTOs.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Validators.Test
{
    public class TestCreateDtoValidator : AbstractValidator<TestCreateDto>
    {
        public TestCreateDtoValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("Test title is required.")
                .MaximumLength(200).WithMessage("Test title can't be longer than 200 characters.");

            RuleFor(t => t.Description)
                .MaximumLength(1000).WithMessage("Description can't be longer than 1000 characters.");
        }
    }
}
