using FlowGuardian.NET.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowGuardian.NET.Domain.Entities
{
    public class SuspiciousDetection
    {
        public bool IsSuspicious { get; set; }
        public double SuspicionScore { get; set; }
        public List<string> Reasons { get; set; } = new();
        public SuspiciousAction RecommendedAction { get; set; }
    }


}
