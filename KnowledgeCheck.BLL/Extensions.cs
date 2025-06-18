using FluentValidation;
using KnowledgeCheck.BLL.DTOs.Answer;
using KnowledgeCheck.BLL.DTOs.Question;
using KnowledgeCheck.BLL.DTOs.Result;
using KnowledgeCheck.BLL.DTOs.Test;
using KnowledgeCheck.BLL.DTOs.User;
using KnowledgeCheck.BLL.Services.Interfaces;
using KnowledgeCheck.BLL.Services;
using KnowledgeCheck.BLL.Validators.Answer;
using KnowledgeCheck.BLL.Validators.Question;
using KnowledgeCheck.BLL.Validators.Result;
using KnowledgeCheck.BLL.Validators.Test;
using KnowledgeCheck.BLL.Validators.User;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using MapsterMapper;

namespace KnowledgeCheck.BLL
{
    public static class Extensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IResultService, ResultService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<UserCreateDto>, UserCreateDtoValidator>();
            services.AddScoped<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();

            services.AddScoped<IValidator<TestCreateDto>, TestCreateDtoValidator>();
            services.AddScoped<IValidator<TestUpdateDto>, TestUpdateDtoValidator>();

            services.AddScoped<IValidator<QuestionCreateDto>, QuestionCreateDtoValidator>();
            services.AddScoped<IValidator<QuestionUpdateDto>, QuestionUpdateDtoValidator>();

            services.AddScoped<IValidator<AnswerCreateDto>, AnswerCreateDtoValidator>();
            services.AddScoped<IValidator<AnswerUpdateDto>, AnswerUpdateDtoValidator>();

            services.AddScoped<IValidator<ResultCreateDto>, ResultCreateDtoValidator>();
            services.AddScoped<IValidator<ResultUpdateDto>, ResultUpdateDtoValidator>();

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
