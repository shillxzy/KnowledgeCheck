using FluentValidation;
using KnowledgeCheck.BLL.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Validators.Question
{
    public class QuestionUpdateDtoValidator : AbstractValidator<QuestionUpdateDto>
    {
        public QuestionUpdateDtoValidator()
        {
            RuleFor(q => q.Text)
                .NotEmpty().WithMessage("Question text is required.")
                .MaximumLength(500).WithMessage("Question text can't be longer than 500 characters.");

        }
    }
}
