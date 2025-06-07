using KnowledgeCheck.BLL.DTOs.Answer;
using KnowledgeCheck.BLL.DTOs.Question;
using KnowledgeCheck.BLL.DTOs.Result;
using KnowledgeCheck.BLL.DTOs.Test;
using KnowledgeCheck.BLL.DTOs.User;
using KnowledgeCheck.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using Mapster;


namespace KnowledgeCheck.BLL.Configuration
{
    public static class MapsterConfig
    {
        private static void RegisterMappings()
        {
            // User
            TypeAdapterConfig<User, UserResponseDto>.NewConfig()
                .Map(dest => dest.Role, src => src.Role)
                .IgnoreNullValues(true);

            TypeAdapterConfig<UserCreateDto, User>.NewConfig();
            TypeAdapterConfig<UserUpdateDto, User>.NewConfig();

            // Test
            TypeAdapterConfig<Test, TestResponseDto>.NewConfig()
                .Map(dest => dest.QuestionCount, src => src.Questions.Count)
                .IgnoreNullValues(true);

            TypeAdapterConfig<TestCreateDto, Test>.NewConfig();
            TypeAdapterConfig<TestUpdateDto, Test>.NewConfig();

            // Question
            TypeAdapterConfig<Question, QuestionResponseDto>.NewConfig()
                .IgnoreNullValues(true);

            TypeAdapterConfig<QuestionCreateDto, Question>.NewConfig();
            TypeAdapterConfig<QuestionUpdateDto, Question>.NewConfig();

            // Answer
            TypeAdapterConfig<Answer, AnswerResponseDto>.NewConfig()
                .IgnoreNullValues(true);

            TypeAdapterConfig<AnswerCreateDto, Answer>.NewConfig();
            TypeAdapterConfig<AnswerUpdateDto, Answer>.NewConfig();

            // Result
            TypeAdapterConfig<Result, ResultResponseDto>.NewConfig()
                .Map(dest => dest.UserName, src => src.User.UserName)
                .Map(dest => dest.TestTitle, src => src.Test.Title)
                .IgnoreNullValues(true);

            TypeAdapterConfig<ResultCreateDto, Result>.NewConfig();
        }

        public static IServiceCollection AddMapsterConfiguration(this IServiceCollection services)
        {
            RegisterMappings();
            services.AddMapster();

            return services;
        }
    }
}
