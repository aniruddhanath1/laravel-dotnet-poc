using NLog;
using System;

namespace Application.Services
{
    public class LoggerService
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogError(string message, Exception? ex = null)
        {
            logger.Error(ex, message);
        }
    }
}
