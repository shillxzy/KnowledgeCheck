using FluentValidation;
using KnowledgeCheck.BLL.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Validators.Question
{
    public class QuestionCreateDtoValidator : AbstractValidator<QuestionCreateDto>
    {
        public QuestionCreateDtoValidator()
        {
            RuleFor(q => q.Text)
                .NotEmpty().WithMessage("Question text is required.")
                .MaximumLength(500).WithMessage("Question text can't be longer than 500 characters.");

            RuleFor(q => q.TestId)
                .GreaterThan(0).WithMessage("TestId must be a positive integer.");
        }
    }
}
