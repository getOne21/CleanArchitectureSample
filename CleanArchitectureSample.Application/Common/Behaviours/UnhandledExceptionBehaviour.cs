using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureSample.Application.Common.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        this.logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception exception)
        {
            var requestName = typeof(TRequest).Name;
            this.logger.LogError(
                exception,
                "CleanArchitecture Request: Unhandled Exception for Request {Name} {@Request}", 
                requestName,
                request);

            throw;
        }
    }
}
