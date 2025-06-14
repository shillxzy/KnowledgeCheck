using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using KnowledgeCheck.DAL.Data;
using KnowledgeCheck.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeCheck.DAL
{
    public static class SeedData
    {
        public static async Task SeedAsync(
            KnowledgeCheckDbContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            await context.Database.MigrateAsync();

            var roles = new[] { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            if (!context.Users.Any())
            {
                var usersFaker = new Faker<User>()
                    .RuleFor(u => u.UserName, f => f.Internet.UserName())
                    .RuleFor(u => u.Email, f => f.Internet.Email())
                    .RuleFor(u => u.CreatedAt, f => f.Date.Past(1).ToUniversalTime());
                var users = usersFaker.Generate(10);

                const string simplePassword = "1234567890";

                foreach (var user in users)
                {
                    user.EmailConfirmed = true;
                    var result = await userManager.CreateAsync(user, simplePassword);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "User");
                    }
                    else
                    {
                        throw new Exception($"Помилка створення користувача: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@knowledgecheck.com",
                    EmailConfirmed = true,
                    CreatedAt = DateTime.UtcNow
                };
                var adminResult = await userManager.CreateAsync(admin, simplePassword);
                if (adminResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            if (!context.Tests.Any())
            {
                var testsFaker = new Faker<Test>()
                    .RuleFor(t => t.Title, f => f.Company.CatchPhrase())
                    .RuleFor(t => t.Description, f => f.Lorem.Sentence())
                    .RuleFor(t => t.CreatedAt, f => f.Date.Past(1));

                var tests = testsFaker.Generate(5);

                foreach (var test in tests)
                {
                    var questionFaker = new Faker<Question>()
                        .RuleFor(q => q.QuestionText, f => f.Lorem.Sentence())
                        .RuleFor(q => q.Test, test);

                    var questions = questionFaker.Generate(new Random().Next(3, 6));

                    foreach (var question in questions)
                    {
                        var answerFaker = new Faker<Answer>()
                            .RuleFor(a => a.AnswerText, f => f.Lorem.Word())
                            .RuleFor(a => a.IsCorrect, f => false)
                            .RuleFor(a => a.Question, question);

                        var answers = answerFaker.Generate(new Random().Next(3, 5));

                        var correctIndex = new Random().Next(answers.Count);
                        answers[correctIndex].IsCorrect = true;

                        question.Answers = answers;
                    }

                    test.Questions = questions;

                    await context.Tests.AddAsync(test);
                }

                await context.SaveChangesAsync();
            }

            if (!context.Results.Any())
            {
                var users = await userManager.Users.ToListAsync();
                var tests = await context.Tests.Include(t => t.Questions).ToListAsync();

                var resultsFaker = new Faker<Result>()
                    .RuleFor(r => r.User, f => f.PickRandom(users))
                    .RuleFor(r => r.Test, f => f.PickRandom(tests))
                    .RuleFor(r => r.Score, f => f.Random.Int(0, 100))
                    .RuleFor(r => r.TakenAt, f => f.Date.Recent());

                var results = resultsFaker.Generate(10);

                await context.Results.AddRangeAsync(results);
                await context.SaveChangesAsync();
            }
        }
    }
}
