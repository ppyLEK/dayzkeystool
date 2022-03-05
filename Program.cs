using System;
using System.IO;
    class Program
    {
        static string destinationFolder = "keys";
    
        static void Main(string[] args)
        {

            string execPath = AppDomain.CurrentDomain.BaseDirectory;
            var files = Directory.GetFiles(execPath, "*.bikey", SearchOption.AllDirectories);
            foreach (string s in files)
            {
                
                string fileName = Path.GetFileName(s);

                string destFile = Path.Combine(execPath + destinationFolder, fileName);
            if (destFile != s)
            {
                Console.WriteLine("Moved " + fileName + " to keys folder.");
                File.Copy(s, destFile, true);
            }
            else
            {
                Console.WriteLine(fileName + "| Key is already in keys folder.");
            }
            }
        }
    }

