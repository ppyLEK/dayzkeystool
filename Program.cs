using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
namespace dayzkeystool
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("Kernel32")]
        private static extern IntPtr GetConsoleWindow();

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static string destinationFolder = "keys";
        static string logFile = "DayZKeysTool.log";
        static int countNewKeys = 0;
        static void Main(string[] args)
        {
            IntPtr hwnd;
            hwnd = GetConsoleWindow();
            ShowWindow(hwnd, SW_HIDE);
            
            string execPath = AppDomain.CurrentDomain.BaseDirectory;
            var files = Directory.GetFiles(execPath, "*.bikey", SearchOption.AllDirectories);

            

            StringBuilder sb = new StringBuilder();
            sb.Append("DayZ Keys Tool logs" +
                "\n---------------------------------------");
            foreach (string s in files)
            {
                string fileName = Path.GetFileName(s);
                string destFile = Path.Combine(execPath + destinationFolder, fileName);
                
                    Boolean result = File.Exists(destFile);
                    if (!result)
                    {
                        countNewKeys++;
                        sb.Append("\n[SUCCESS] - Moved key to destination folder (" + fileName + ").");
                        File.Copy(s, destFile, true);
                    }

                                
            }
            if(countNewKeys == 0)
                sb.Append("\n[SUCCESS] - No new keys found.");

            if(files.Length == 0)
                sb.Append("\nDayZ Keys Tool could not find any .bikeys in this directory." +
                    "\nPlease make sure you copy this .exe to the same folder where you have" +
                    "\nDayZ_x64.exe or DayZServer_x64.exe");
            sb.Append("\n[SUMMARY] - Moved total of (" + countNewKeys.ToString() + ") keys to keys folder.");
            File.AppendAllText(execPath + logFile, sb.ToString());
            sb.Clear();
            Form1 form = new Form1();
            System.Windows.Forms.Application.Run(form);
            
        }

        
    }
}
