using System;
using System.IO;
using System.Web;
using NLog;

namespace DataFlow.Common.Services
{
    public class NLogService : ICentralLogger
    {
        public string Name { get; set; }

        private readonly ILogger _logger;

        public NLogService(ILogger logger)
        {
            this.Name = "DataFlow Logger";
            this._logger = logger;
        }

        public void Debug(string message, Exception e = null)
        {
            Log(LogLevel.Debug, message, e);
        }

        public void Error(string message, Exception e = null)
        {
            Log(LogLevel.Error, message, e);
        }

        public void Fatal(string message, Exception e = null)
        {
            Log(LogLevel.Fatal, message, e);
        }

        public void Info(string message, Exception e = null)
        {
            Log(LogLevel.Info, message, e);
        }

        public void Trace(string message, Exception e = null)
        {
            Log(LogLevel.Trace, message, e);
        }

        public void Warn(string message, Exception e = null)
        {
            Log(LogLevel.Warn, message, e);
        }

        private void Log(LogLevel level, string message, Exception e)
        {
            var requestBody = "";
            try
            {
                requestBody = GetRequestBody(HttpContext.Current.Request);
            }
            catch { }

            LogEventInfo ev = new LogEventInfo(level, this.Name, message);
            ev.Exception = e;
            ev.Properties["requestBody"] = requestBody;

            _logger.Log(ev);
            return;
        }

        private static string GetRequestBody(HttpRequest r)
        {
            Stream req = r.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            StreamReader s = new StreamReader(req);
            return s.ReadToEnd();
        }
    }
}