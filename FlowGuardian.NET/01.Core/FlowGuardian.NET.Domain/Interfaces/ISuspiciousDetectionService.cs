using FlowGuardian.NET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Interfaces
{
    public interface ISuspiciousDetectionService
    {
        Task<SuspiciousDetection> AnalyzeRequestAsync(RequestInfo request);
        Task<bool> IsSuspiciousPatternAsync(string pattern);
        Task ReportSuspiciousActivityAsync(RequestInfo request, string reason);
    }
}
