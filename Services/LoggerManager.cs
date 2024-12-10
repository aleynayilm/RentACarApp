using Microsoft.AspNetCore.Http;
using NLog;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoggerManager : ILoggerServices
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggerManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void LogDebug(string message, string? userId = null, string? adminId = null)
        {
            var logEvent = CreateLogEvent(LogLevel.Debug, message, userId, adminId);
            logger.Log(logEvent);
        }

        public void LogError(string message, string? userId = null, string? adminId = null)
        {
            var logEvent = CreateLogEvent(LogLevel.Error, message, userId, adminId);
            logger.Log(logEvent);
        }

        public void LogInfo(string message, string? userId = null, string? adminId = null)
        {
            var logEvent = CreateLogEvent(LogLevel.Info, message, userId, adminId);
            logger.Log(logEvent);
        }

        public void LogWarning(string message, string? userId = null, string? adminId = null)
        {
            var logEvent = CreateLogEvent(LogLevel.Warn, message, userId, adminId);
            logger.Log(logEvent);
        }

        private LogEventInfo CreateLogEvent(LogLevel level, string message, string? userId, string? adminId)
        {
            var logEvent = new LogEventInfo(level, logger.Name, message);
            string currentUserId = GetCurrentUserId();
            logEvent.Properties["UserId"] = userId ?? (adminId == null ? currentUserId : null);
            logEvent.Properties["AdminId"] = adminId ?? (userId == null ? currentUserId : null);
            return logEvent;
        }
        private string GetCurrentUserId()
        {
            var claims = _httpContextAccessor.HttpContext?.User.Claims;

            // Kullanıcı ID veya Admin ID'yi email'den al
            var emailClaim = claims?.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email)?.Value;

            // Eğer email mevcutsa, ID'yi database'den bulabilirsiniz
            return emailClaim ?? "Unknown";
        }
    }
}
