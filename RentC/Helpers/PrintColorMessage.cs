using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC_ConsoleApplication.Helpers
{
    public class PrintColorMessage
    {
        //Print color message and reset text color back
        public void Print(ConsoleColor color, string message)
        {
            // Change text color
            Console.ForegroundColor = color;

            // Print the custom message
            Console.WriteLine(message);

            // Reset text color
            Console.ResetColor();
        }
    }
}
