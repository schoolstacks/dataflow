namespace DataFlow.Common.Services
{
    public interface ICentralLogger
    {
        string Name { get; set; }

        void Debug(string message, System.Exception e = null);
        void Error(string message, System.Exception e = null);
        void Fatal(string message, System.Exception e = null);
        void Info(string message, System.Exception e = null);
        void Trace(string message, System.Exception e = null);
        void Warn(string message, System.Exception e = null);
    }
}