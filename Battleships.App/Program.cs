using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.App.Components;
using Battleships.App.Core;
using Battleships.App.Utils;

namespace Battleships.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.ShowWelcomeScreen();
            
            Console.Write("Click ENTER to start or any other button to leave: ");
            
            //restart game on ENTER, end game on any other key
            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                // read size of the map, if improper read again
                var sizeString = "";
                while (!sizeString.IsProperSize())
                {
                    sizeString = ConsoleHelper.GetOption("Enter proper size of the map: ");
                }

                // read number of battleships
                var battleshipsString = "";
                while (!battleshipsString.IsProperShipsNumber())
                {
                    battleshipsString = ConsoleHelper.GetOption("Enter number of battleships (5 length): ");
                }

                // read number of cruisers
                var destroyersString = "";
                while (!destroyersString.IsProperShipsNumber())
                {
                    destroyersString = ConsoleHelper.GetOption("Enter number of destroyers (4 length): ");
                }
            
                //convert options to int
                int size = Convert.ToInt32(sizeString);
                int battleshipsNumber = Convert.ToInt32(battleshipsString);
                int destroyersNumber = Convert.ToInt32(destroyersString);
                
                //new game
                var game = new Game(size)
                {
                    Ships = ShipCreator.CreateShips(destroyersNumber, battleshipsNumber, size)
                };
                
                //game loop
                bool allDestroyed = false;
                while (!allDestroyed)
                {
                    var shot = Console.ReadLine();
                    game.MakeShot(shot);

                    if (game.Ships.All(s => s.IsDestroyed())) 
                        allDestroyed = true;
                }
            
                //user won
                ConsoleHelper.ShowYouWinScreen(size); 
            }
            
        }
    }
}