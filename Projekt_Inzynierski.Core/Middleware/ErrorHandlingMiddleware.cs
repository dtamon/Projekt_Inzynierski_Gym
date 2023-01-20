using Microsoft.AspNetCore.Http;
using Projekt_Inzynierski.Core.Exceptions;

namespace Projekt_Inzynierski.Core.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (TrainingCollisionException trainingCollisionException)
            {
                context.Response.StatusCode = 421;
                await context.Response.WriteAsync(trainingCollisionException.Message);
            }
            catch (EmailIsTakenException emailIsTakenException)
            {
                context.Response.StatusCode = 422;
                await context.Response.WriteAsync(emailIsTakenException.Message);
            }
            catch (PeselIsTakenException peselIsTakenException)
            {
                context.Response.StatusCode = 423;
                await context.Response.WriteAsync(peselIsTakenException.Message);
            }
            catch (PhoneNrIsTakenException phoneNrIsTakenException)
            {
                context.Response.StatusCode = 424;
                await context.Response.WriteAsync(phoneNrIsTakenException.Message);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch (BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Coś poszło nie tak");
            }
        }
    }
}
