using FluentValidation;
using KnowledgeCheck.BLL.DTOs.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Validators.Answer
{
    public class AnswerCreateDtoValidator : AbstractValidator<AnswerCreateDto>
    {
        public AnswerCreateDtoValidator()
        {
            RuleFor(a => a.Text)
                .NotEmpty().WithMessage("Answer text is required.")
                .MaximumLength(300).WithMessage("Answer text can't be longer than 300 characters.");

            RuleFor(a => a.QuestionId)
                .GreaterThan(0).WithMessage("QuestionId must be a positive integer.");
        }
    }
}
