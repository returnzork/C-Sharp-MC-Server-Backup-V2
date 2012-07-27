using System;
using System.IO;

namespace BackupV2
{
    public class Error_Logging
    {
        public void MakeLog(Exception ex, string exception2)
        {
            FileStream fs = null;
            if (!Directory.Exists(Environment.GetEnvironmentVariable("appdata") + "\\returnzork"))
            {
                Directory.CreateDirectory(Environment.GetEnvironmentVariable("appdata") + "\\returnzork");
            }
            if (!File.Exists(Environment.GetEnvironmentVariable("appdata") + "\\returnzork\\Error.log"))
            {
                fs = new FileStream(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Error.log", FileMode.CreateNew, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Error.log", FileMode.Append, FileAccess.Write);
            }
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("\r\n" + DateTime.Now.ToString() + ex + "  " + exception2);
            sw.Close();
            fs.Close();
        }
    }
}
