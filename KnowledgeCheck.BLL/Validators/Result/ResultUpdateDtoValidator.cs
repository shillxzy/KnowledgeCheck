using FluentValidation;
using KnowledgeCheck.BLL.DTOs.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Validators.Result
{
    public class ResultUpdateDtoValidator : AbstractValidator<ResultUpdateDto>
    {
        public ResultUpdateDtoValidator()
        {
            RuleFor(r => r.Score)
                .GreaterThanOrEqualTo(0).WithMessage("Score can't be negative.");

            RuleFor(r => r.TakenAt)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("TakenAt can't be in the future.");
        }
    }
}
