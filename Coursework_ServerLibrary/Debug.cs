using System;
using System.Collections.Generic;
using System.Text;

namespace Coursework_ServerLibrary
{
    public static class Debug
    {
        public static event Action Changed;
        public static string ChangedContent { get; private set; }

        public static void Write(string message)
        {
            ChangedContent += message;
            Changed?.Invoke();
        }

        public static void WriteLine(string message)
        {
            ChangedContent += message + "\r\n";
            Changed?.Invoke();
        }
        public static void WriteLine()
        {
            ChangedContent += "\r\n";
            Changed?.Invoke();
        }

        public static void ClearChangedContent() => ChangedContent = "";
    }
}
