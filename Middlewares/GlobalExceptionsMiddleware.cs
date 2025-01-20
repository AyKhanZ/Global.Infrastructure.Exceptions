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
        catch (PersonalAccountException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (MarketingException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (VacancyException ex)
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
            case IdentityErrorType.InvalidRefreshToken:
            case IdentityErrorType.InvalidCredentials:
            case IdentityErrorType.PasswordMismatch:
            case IdentityErrorType.EmailNotConfirmed:
                code = HttpStatusCode.Unauthorized;
                break;
            case IdentityErrorType.EmailAlreadyExist:
            case IdentityErrorType.InvalidRequest:
                code = HttpStatusCode.BadRequest;
                break;
            case IdentityErrorType.InvalidToken:
                code = (HttpStatusCode)498;
                break;
            case IdentityErrorType.EmailAlreadyConfirmed:
                code = HttpStatusCode.NoContent;
                break;
            case IdentityErrorType.FileNotFound:
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
            case MarketingErrorType.FileNotFound:
            case MarketingErrorType.CRMNotFound:
            case MarketingErrorType.NewsNotFound:
            case MarketingErrorType.PartnerNotFound:
            case MarketingErrorType.TranslationNotFound:
                code = HttpStatusCode.NotFound;
                break;
            case MarketingErrorType.PartnerAlreadyExists:
                code = HttpStatusCode.Conflict;
                break;
            case MarketingErrorType.InvalidRequest:
                code = HttpStatusCode.BadRequest;
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
            case VacancyErrorType.WorkExperienceNotFound:
            case VacancyErrorType.EducationNotFound:
            case VacancyErrorType.ContactInfoNotFound:
            case VacancyErrorType.PersonalInfoNotFound:
            case VacancyErrorType.AdditionalInfoNotFound:
            case VacancyErrorType.ResumeNotFound:
                code = HttpStatusCode.NotFound;
                break;
            
            case VacancyErrorType.VacancyNotActual:
                code = HttpStatusCode.BadRequest;
                break;
            
            case VacancyErrorType.ResumeAlreadyExists:
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
            case PersonalAccountErrorType.FileNotFound:
            case PersonalAccountErrorType.UserNotFound:
            case PersonalAccountErrorType.ClientNotFound:
            case PersonalAccountErrorType.CompanyNotFound:
            case PersonalAccountErrorType.VoenNotFound:
            case PersonalAccountErrorType.TypeOfActivityNotFound:
            case PersonalAccountErrorType.ProductNotFound:
            case PersonalAccountErrorType.StaffNotFound:
            case PersonalAccountErrorType.CertificateNotFound:
            case PersonalAccountErrorType.ProjectNotFound:
            case PersonalAccountErrorType.TicketNotFound:
            case PersonalAccountErrorType.SubTicketNotFound:
            case PersonalAccountErrorType.TaskNotFound:
            case PersonalAccountErrorType.CheckListNotFound:
            case PersonalAccountErrorType.NotificationNotFound:
            case PersonalAccountErrorType.CommentNotFound:
            case PersonalAccountErrorType.ReactionNotFound:
                code = HttpStatusCode.NotFound;
                break;

            case PersonalAccountErrorType.UserAlreadyExists:
            case PersonalAccountErrorType.ClientAlreadyExists:
            case PersonalAccountErrorType.StaffAlreadyExists:
            case PersonalAccountErrorType.EmailAlreadyExists:
            case PersonalAccountErrorType.ProjectAlreadyExists:
            case PersonalAccountErrorType.TicketAlreadyExists:
            case PersonalAccountErrorType.SubTicketAlreadyExists:
            case PersonalAccountErrorType.TaskAlreadyExists:
            case PersonalAccountErrorType.CheckListAlreadyExists:
            case PersonalAccountErrorType.CommentAlreadyExists:
            case PersonalAccountErrorType.ReactionAlreadyExists:
            case PersonalAccountErrorType.NotificationAlreadyExists:
                code = HttpStatusCode.Conflict;
                break;

            case PersonalAccountErrorType.VoenIsNull:
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
