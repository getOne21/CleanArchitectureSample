using CleanArchitectureSample.Application.Common.Interfaces;

namespace CleanArchitectureSample.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}
