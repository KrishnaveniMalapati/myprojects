using MSys.Library.Logger.Interface;
using MSys.Library.Logger.Model;
using System.Runtime.CompilerServices;

public class CustomLoggerService : ILoggerService
{

    private static readonly Lazy<CustomLoggerService> lazyInstance = new Lazy<CustomLoggerService>(() => new CustomLoggerService());
    private string _logFilePath;

    public CustomLoggerService(string? logFilePath = null)
    {
        // Set the path to the log file (customize as needed)
        // logFilePath = "path_to_log_file.log"; // You can set a default file name here
        this._logFilePath = GetLogFileName(logFilePath);
    }

    public static CustomLoggerService Instance => lazyInstance.Value;

    public void Write(string message, LogLevel loglevel = LogLevel.Debug, [CallerMemberName] string memberName = "",
                      [CallerFilePath] string sourceFilePath = "",
                      [CallerLineNumber] int sourceLineNumber = 0)
    {
        try
        {
            File.AppendAllText(this._logFilePath, $"[{DateTime.Now:HH:mm:ss.fff yyyy-MM-dd}] [{Thread.CurrentThread.ManagedThreadId}] [{Path.GetFileName(sourceFilePath)}, {memberName}, {sourceLineNumber}] [{loglevel}]: {message}{Environment.NewLine}");
        }
        catch { }
    }

    public void Write(Exception ex, [CallerMemberName] string memberName = "",
                              [CallerFilePath] string sourceFilePath = "",
                              [CallerLineNumber] int sourceLineNumber = 0)
    {
        try
        {
            Write($"{ex}{Environment.NewLine}{ex.StackTrace}", loglevel: LogLevel.Info, memberName, sourceFilePath, sourceLineNumber);
        }
        catch { }   // It's required in case of any IO exception

    }

   // Method to set the log file name dynamically
    public string GetLogFileName(string logFileName)
    {
        // Combine the provided log file name with the desired directory path
        // Replace "directory_path" with your desired directory path

        logFileName = "c:/logs/Msys/log.text";

        if (!File.Exists(logFileName))
        {
            // return Path.Combine("", logFileName);

            var path = Directory.GetParent(logFileName).FullName;

           Directory.CreateDirectory(path);
        }
        return Path.Combine("", logFileName);
    }


    //public string GetLogFileName(string logFileName)
    //{
    //    string directoryPath = @"C:\Your\Directory\Path"; // Replace with your desired directory path
    //    return Path.Combine(directoryPath, logFileName);
    //}
}


// Specify the directory path you want to create (replace with your desired path)
//string directoryPath = @"C:\Your\Desired\Directory\Path";

//try
//{
//    // Attempt to create the directory
//    Directory.CreateDirectory(directoryPath);

//    Console.WriteLine("Directory created successfully.");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error creating directory: {ex.Message}");
//}

