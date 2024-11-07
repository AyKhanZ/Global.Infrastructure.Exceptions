using System.Net;
using Global.Infrastructure.Exceptions.Identity;
using Global.Infrastructure.Exceptions.Marketing;
using Global.Infrastructure.Exceptions.PersonalAccount;
using Global.Infrastructure.Exceptions.Vacancy;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Global.Infrastructure.Middlewares;

public class GlobalExceptionsMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (IdentityException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private Task HandleExceptionAsync(HttpContext context, IdentityException exception)
    {
        var code = HttpStatusCode.InternalServerError;
        
        switch (exception.AuthErrorType)
        {
            case IdentityErrorType.InvalidCredentials:
                code = HttpStatusCode.Unauthorized;
                break;
            case IdentityErrorType.InvalidRequest:
                code = HttpStatusCode.BadRequest;
                break;
            case IdentityErrorType.InvalidToken:
                code = (HttpStatusCode)498;
                break;
            case IdentityErrorType.PasswordMismatch:
                code = HttpStatusCode.Unauthorized;
                break;
            case IdentityErrorType.EmailAlreadyConfirmed:
                code = HttpStatusCode.NoContent;
                break;
            case IdentityErrorType.EmailNotConfirmed:
                code = HttpStatusCode.Unauthorized;
                break;
            case IdentityErrorType.UserNotFound:
                code = HttpStatusCode.NotFound;
                break;
        }
        
        var result = JsonConvert.SerializeObject(new { error = exception.Message});
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }

    private Task HandleExceptionAsync(HttpContext context, MarketingException exception)
    {
        var code = HttpStatusCode.InternalServerError;

        switch (exception.MarketingErrorType)
        {
            case MarketingErrorType.CRMNotFound:
            case MarketingErrorType.NewsNotFound:
            case MarketingErrorType.PartnerNotFound:
            case MarketingErrorType.TranslationNotFound:
                code = HttpStatusCode.NotFound;
                break;
            case MarketingErrorType.PartnerAlreadyExists:
                code = HttpStatusCode.Conflict;
                break;
        }

        var result = JsonConvert.SerializeObject(new { error = exception.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }

    private Task HandleExceptionAsync(HttpContext context, VacancyException exception)
    {
        var code = HttpStatusCode.InternalServerError;

        switch (exception.ErrorType)
        {
            case VacancyErrorType.VacancyNotFound:
                code = HttpStatusCode.NotFound;
                break;
            case VacancyErrorType.ResumeNotFound:
                code = HttpStatusCode.NotFound;
                break;

            case VacancyErrorType.ResumeAlreadyExists:
                code = HttpStatusCode.Conflict;
                break;
            case VacancyErrorType.UserAlreadyExists:
                code = HttpStatusCode.Conflict;
                break;
            case VacancyErrorType.VacancyAlreadyExists:
                code = HttpStatusCode.Conflict;
                break;
        }

        var result = JsonConvert.SerializeObject(new { error = exception.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }

    private Task HandleExceptionAsync(HttpContext context, PersonalAccountException exception)
    {
        var code = HttpStatusCode.InternalServerError;

        switch (exception.ErrorType)
        {
            case PersonalAccountErrorType.UserNotFound:
            case PersonalAccountErrorType.ClientNotFound:
            case PersonalAccountErrorType.CompanyNotFound:
            case PersonalAccountErrorType.StaffNotFound:
            case PersonalAccountErrorType.VoenNotFound:
            case PersonalAccountErrorType.TypeOfActivityNotFound:
            case PersonalAccountErrorType.CommentNotFound:
            case PersonalAccountErrorType.ProjectTaskNotFound:
            case PersonalAccountErrorType.ProjectSubTicketNotFound:
            case PersonalAccountErrorType.ProjectTicketUserNotFound:
            case PersonalAccountErrorType.ProjectNotFound:
            case PersonalAccountErrorType.ProjectTicketNotFound:
                code = HttpStatusCode.NotFound;
                break;
            case PersonalAccountErrorType.SerteficateNotFound:
                code = HttpStatusCode.NotFound;
                break;
            case PersonalAccountErrorType.ProductNotFound:
                code = HttpStatusCode.NotFound;
                break;

            case PersonalAccountErrorType.UserAlreadyExists:
            case PersonalAccountErrorType.ClientAlreadyExists:
            case PersonalAccountErrorType.StaffAlreadyExists:
            case PersonalAccountErrorType.ProjectSubTicketAlreadyExists:
            case PersonalAccountErrorType.EmailAlreadyExists:
            case PersonalAccountErrorType.ProjectTicketAlreadyExists:
                code = HttpStatusCode.Conflict;
                break;
            case PersonalAccountErrorType.ProjectAlreadyExists:
                code = HttpStatusCode.Conflict;
                break;

            case PersonalAccountErrorType.ConcurrencyError:
            case PersonalAccountErrorType.InvalidTaskState:
                code = HttpStatusCode.Conflict;
                break;

            case PersonalAccountErrorType.TaskRoleNotFound:
            case PersonalAccountErrorType.GeneralError:
                code = HttpStatusCode.BadRequest;
                break;
            
        }

        var result = JsonConvert.SerializeObject(new { error = exception.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }




    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        
        var result = JsonConvert.SerializeObject(new { error = exception.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}