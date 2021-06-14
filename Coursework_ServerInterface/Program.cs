using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_ServerInterface
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Form1());
        //}
        [STAThread]
        static void Main()
        {
            using (var consoleWriter = new ConsoleWriter())
            {
                consoleWriter.WriteEvent += consoleWriter_WriteEvent;
                consoleWriter.WriteLineEvent += consoleWriter_WriteLineEvent;

                Console.SetOut(consoleWriter);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }

        static void consoleWriter_WriteLineEvent(object sender, ConsoleWriterEventArgs e)
        {
            ConsoleText += e.Value + "\r\n";
            _consoleTextUpdated?.Invoke();
            //MessageBox.Show(e.Value, "WriteLine");
        }

        static void consoleWriter_WriteEvent(object sender, ConsoleWriterEventArgs e)
        {
            ConsoleText += e.Value;
            _consoleTextUpdated?.Invoke();
            //MessageBox.Show(e.Value, "Write");
        }

        public static string ConsoleText { get; private set; }
        public static bool TryReadNewText(out string text)
        {
            text = "";
            if (ConsoleText != null)
            {
                text = string.Copy(ConsoleText);
                ConsoleText = "";
                return true;
            }
            return false;
        }

        private static Action _consoleTextUpdated;
        public static event Action ConsoleTextUpdated
        {
            add => _consoleTextUpdated += value;
            remove => _consoleTextUpdated -= value;
        }
    }
}
