using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;

namespace FormulaAllCode
{
    class Program
    {
        // Change the value of PORT to your own port. See the README.md file for how to find your port.
        public const char PORT = (char)6;
        static void Main(string[] args)
        {
            try
            {
                // Connect to the Robot
                FA_DLL.FA_ComOpen(PORT);
            }
            finally
            {
                FA_DLL.FA_ComClose(PORT);
            }
        }
    }
}