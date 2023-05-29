using Microsoft.Extensions.Logging;

namespace LiberalChat_desktop.src.ErrorMessage
{
    internal class ErrorMessage
    {
        //Logger
        public readonly ILogger _logger;

        public ErrorMessage(ILoggerFactory loggerFactory) =>
            _logger = loggerFactory.CreateLogger("logger");

        enum ErrorType
        {
            Debug,Info,Warning,Error,
        }

        public void SendMessageDebug(string info) => ProcessInfo(ErrorType.Debug, info);
        public void SendMessageInfo(string info) => ProcessInfo(ErrorType.Info, info);
        public void SendMessageWarning(string info) => ProcessInfo(ErrorType.Warning, info);
        public void SendMessageError(string info) => ProcessInfo(ErrorType.Error, info);

        private void ProcessInfo(ErrorType type,string info)
        {
            switch (type)
            {
                case ErrorType.Debug:
                    _logger.LogDebug(info); 
                    break;
                case ErrorType.Info:
                    _logger.LogDebug(info);
                    break;
                case ErrorType.Warning:
                    _logger.LogWarning(info);
                    break;
                case ErrorType.Error:
                    _logger.LogError(info);
                    break;
            }
            //TODO:传递信息到用户界面
        }
    }
}
