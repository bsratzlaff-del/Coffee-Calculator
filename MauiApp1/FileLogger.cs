using System;
using System.IO;

namespace MauiApp1;

public static class FileLogger
{
    // Path: /data/user/0/com.companyname.mauiapp1/files/debug_log.txt
    private static string LogPath => Path.Combine(FileSystem.AppDataDirectory, "debug_log.txt");

    public static void Log(string message, string category = "DEBUG")
    {
        try
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"[{timestamp}] [{category}] {message}{Environment.NewLine}";

            // This appends the text to the file. If the file doesn't exist, it creates it.
            File.AppendAllText(LogPath, logEntry);
        }
        catch (Exception ex)
        {
            // If the logger fails, we fall back to terminal just in case
            System.Diagnostics.Debug.WriteLine($"Logger failed: {ex.Message}");
        }
    }

    public static string GetLogFilePath() => LogPath;

    public static void ClearLog() => File.WriteAllText(LogPath, string.Empty);
}