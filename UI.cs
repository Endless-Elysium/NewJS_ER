using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewERScaling
{
    internal static class UI
    {
        public static void WriteLine(string Message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
