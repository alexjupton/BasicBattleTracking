using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Logger
    {
        public RichTextBox LogBox { get; set; }
        public string OutputPath { get; set; }

        public Logger()
        {
            OutputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SecretSanta", $"{DateTime.Today.ToString("yyyy-MM-dd")}.log");
        }

        public async Task Log(string message)
        {
            LogBox.AppendText($"\n{message}");
            await WriteFile(message);
        }

        public async Task WriteFile(string message)
        {
            if (!File.Exists(OutputPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(OutputPath));
                File.Create(OutputPath);
            }
            var currentTime = DateTime.Now.ToLocalTime();
            await Task.Run(()=>File.AppendAllText(OutputPath, $"\n{currentTime} - {message}"));
        }
    }
}
