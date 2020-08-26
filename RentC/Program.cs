using RentC.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoDb;
using RentC.Helpers;
using RentCar.Helpers;

namespace RentC
{
    class Program
    {
        static void Main(string[] args)
        {
            // SQL Server Connection
            SqlServerBootstrap.Initialize();

            // Instantiate Menu and WelcomeText 
            Menu menu = new Menu();
            WelcomeText welcomeText = new WelcomeText();

            // Method for displaing Welcome screen (see Helper folder for refference)
            welcomeText.Print();


            /*Navigation to Menu or Exit of the application.
            If 'Enter' is pressed -> Menu
            else if 'Escape' || another key pressed -> close app*/
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    menu.Index();
                    break;
                case ConsoleKey.Escape:
                    { }
                    break;
            }
        }
    }
}
