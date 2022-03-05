using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dayzkeystool
{
    public partial class Form1 : Form
    {
        string execPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
        static string logFile = "DayZKeysTool.log";
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string log = System.IO.File.ReadAllText(execPath + logFile);
            richTextBox1.AppendText(log.ToString());

            if (!Directory.Exists(execPath + "/dayzkeystool"))
                Directory.CreateDirectory(execPath + "/dayzkeystool");
            if (!File.Exists(execPath + "/dayzkeystool/@readme.txt"))
                File.Create(execPath + "dayzkeystool/@readme.txt");
            CreateLogReadmeFolder(execPath);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(execPath + logFile);
            
            fi.MoveTo(execPath+"/dayzkeystool/"+"DayZKeysTool "+DateTime.Now.ToString("HH-mm-ss - dd-MM-yyyy") + ".log");
            Environment.Exit(0);
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ppyLEK/dayzkeystool/");
        }
        static void CreateLogReadmeFolder(string execPath)
        {

            System.Net.WebClient wc = new System.Net.WebClient();
            byte[] raw = wc.DownloadData("http://raw.githubusercontent.com/ppyLEK/dayzkeystool/master/README.md");
            string readme = Encoding.UTF8.GetString(raw);
            using (StreamWriter sw = new StreamWriter(execPath + "/dayzkeystool/@readme.txt"))
                sw.WriteLine(readme);
            
        }
    }
}
