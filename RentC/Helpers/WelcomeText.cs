using RentC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Helpers
{
    public class WelcomeText
    {

        public void Print()
        {

            PrintColorMessage printColorMessage = new PrintColorMessage();

            // Print Welcome message
            printColorMessage.Print(ConsoleColor.Green, "\n\n   Welcome to RentC, your brand new solution to manage and control       your company's data without missing anything.");

            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

            printColorMessage.Print(ConsoleColor.Yellow, "\t Press 'ENTER' to continue or 'ESC' to quit.");
        }
    }
}
