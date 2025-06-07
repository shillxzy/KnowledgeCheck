using FluentValidation;
using KnowledgeCheck.BLL.DTOs.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeCheck.BLL.Validators.Result
{
    public class ResultCreateDtoValidator : AbstractValidator<ResultCreateDto>
    {
        public ResultCreateDtoValidator()
        {
            RuleFor(r => r.UserId)
                .GreaterThan(0).WithMessage("UserId must be a positive integer.");

            RuleFor(r => r.TestId)
                .GreaterThan(0).WithMessage("TestId must be a positive integer.");

            RuleFor(r => r.Score)
                .GreaterThanOrEqualTo(0).WithMessage("Score can't be negative.");

        }
    }
}
