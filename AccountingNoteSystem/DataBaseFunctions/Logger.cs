using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFunctions
{
    /// <summary> Error Log Record </summary>
    public class Logger
    {
        /// <summary> 紀錄Error Log </summary>
        /// <param name="ex">Exception訊息</param>
        public static void LogWriter(Exception ex)
        {
            string msg =
                $@" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
                        {ex.ToString()}
                ";
            // Set folder path
            string LogPath = "\\ErrLogs\\Log.log";
            string FolderPath = System.IO.Path.GetDirectoryName(LogPath);

            // check path exist
            if (!System.IO.Directory.Exists(FolderPath))
                System.IO.Directory.CreateDirectory(FolderPath);

            // check file exist
            if (!System.IO.File.Exists(LogPath))
                System.IO.File.Create(LogPath);

            // write log file
            System.IO.File.AppendAllText(LogPath, msg);
            throw ex;
        }
    }
}
