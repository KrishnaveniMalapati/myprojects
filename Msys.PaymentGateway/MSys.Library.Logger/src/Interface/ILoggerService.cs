using MSys.Library.Logger.Model;
using System.Runtime.CompilerServices;

namespace MSys.Library.Logger.Interface
{

    public interface ILoggerService
    {

        void Write(string message, LogLevel loglevel = LogLevel.Info, [CallerMemberName] string memberName = "",
                            [CallerFilePath] string sourceFilePath = "",
                            [CallerLineNumber] int sourceLineNumber = 0);
        void Write(Exception ex, [CallerMemberName] string memberName = "",
                        [CallerFilePath] string sourceFilePath = "",
                        [CallerLineNumber] int sourceLineNumber = 0);
    }
}

