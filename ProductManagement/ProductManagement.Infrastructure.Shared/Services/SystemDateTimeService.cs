using ProductManagement.Application.Interfaces.Shared;
using System;

namespace ProductManagement.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}