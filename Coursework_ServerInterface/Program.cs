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
            MessageBox.Show(e.Value, "WriteLine");
        }

        static void consoleWriter_WriteEvent(object sender, ConsoleWriterEventArgs e)
        {
            MessageBox.Show(e.Value, "Write");
        }
    }
}
