using KnowledgeCheck.BLL.Exceptions;
using System.Net;
using System.Text.Json;

namespace KnowledgeCheck.JWT.Middlewares;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred while processing request: {Path}", context.Request.Path);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var (statusCode, title, detail) = exception switch
        {
            AnswerNotFoundException => (HttpStatusCode.NotFound, "Answer Not Found", exception.Message),
            QuestionNotFoundException => (HttpStatusCode.NotFound, "Question Not Found", exception.Message),
            TestNotFoundException => (HttpStatusCode.NotFound, "Test Not Found", exception.Message),
            ResultNotFoundException => (HttpStatusCode.NotFound, "Result Not Found", exception.Message),
            UserNotFoundException => (HttpStatusCode.NotFound, "User Not Found", exception.Message),
            UserAlreadyExistsException => (HttpStatusCode.Conflict, "User Already Exists", exception.Message),
            ConflictException => (HttpStatusCode.Conflict, "Conflict", exception.Message),
            InvalidCredentialsException => (HttpStatusCode.BadRequest, "Invalid Credentials", exception.Message),
            ArgumentException => (HttpStatusCode.BadRequest, "Invalid Argument", exception.Message),
            UnauthorizedAccessException => (HttpStatusCode.Unauthorized, "Unauthorized", "Unauthorized access. Please login."),

            _ => (HttpStatusCode.InternalServerError, "Server Error", "An unexpected error occurred.")
        };

        var problemDetails = new
        {
            status = (int)statusCode,
            title,
            detail,
            instance = context.Request.Path
        };

        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = (int)statusCode;

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails, options));
    }
}
