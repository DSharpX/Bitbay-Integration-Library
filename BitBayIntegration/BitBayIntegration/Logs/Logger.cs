using NLog;
using System;

namespace BitBayIntegration.Logs
{
    public static class Logger
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public static void Error(Exception e)
        {
            _logger.Error("ERROR | " + e, e.Message);
        }
        public static void Info(string msg)
        {
            _logger.Info("INFO | " + msg);
        }
        public static void Trace(string msg)
        {
            _logger.Trace("TRACE | " + msg);
        }
        public static void Warn(string msg)
        {
            _logger.Warn("WARNING | " + msg);
        }
        public static void Debug(string msg)
        {
            _logger.Debug("DEBUG | " + msg);
        }
    }
}
