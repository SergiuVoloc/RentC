using RentC.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC.Helpers
{
    class Navigation
    {
        // Method for realizing navigation to Menu after a particular screen.
        public void GoToMenu()
        {
            Menu menu = new Menu();
            PrintColorMessage colorMessage = new PrintColorMessage();

            colorMessage.Print(ConsoleColor.Yellow, "\n\tPress ENTER to navigate to Menu or ESC to quit");

            switch (Console.ReadKey().Key.ToString())
            {
                case "Enter":
                    menu.Index();
                    break;
                case "Escape":
                    { }
                    break;
            }
        }
    }
}
