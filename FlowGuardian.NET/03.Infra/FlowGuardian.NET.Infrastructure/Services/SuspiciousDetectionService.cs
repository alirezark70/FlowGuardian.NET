using FlowGuardian.NET.Domain.Entities;
using FlowGuardian.NET.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Infrastructure.Services
{
    public class SuspiciousDetectionService : ISuspiciousDetectionService
    {
        public Task<SuspiciousDetection> AnalyzeRequestAsync(RequestInfo request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsSuspiciousPatternAsync(string pattern)
        {
            throw new NotImplementedException();
        }

        public Task ReportSuspiciousActivityAsync(RequestInfo request, string reason)
        {
            throw new NotImplementedException();
        }
    }
}
