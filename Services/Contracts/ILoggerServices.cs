using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILoggerServices
    {
        void LogInfo(string message, string? userId = null, string? adminId = null);
        void LogWarning(string message, string? userId = null, string? adminId = null);
        void LogError(string message, string? userId = null, string? adminId = null);
        void LogDebug(string message, string? userId = null, string? adminId = null);
    }
}
