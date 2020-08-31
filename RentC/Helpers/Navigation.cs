using RentC_ConsoleApplication.Pages;
using RepoDb.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC_ConsoleApplication.Helpers
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

        //implementation with custom text for Menu options
        public void GoToMenu(string Text)
        {
            PrintColorMessage colorMessage = new PrintColorMessage();
            Menu menu = new Menu();
            

            colorMessage.Print(ConsoleColor.Yellow, Text);

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
