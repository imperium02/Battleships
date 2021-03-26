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

            // read size of the map, if improper read again
            var sizeString = Console.ReadLine();
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
            var cruisersString = "";
            while (!cruisersString.IsProperShipsNumber())
            {
                cruisersString = ConsoleHelper.GetOption("Enter number of cruisers (4 length): ");
            }
            
            //convert options to int
            int size = Convert.ToInt32(sizeString);
            int battleshipsNumber = Convert.ToInt32(battleshipsString);
            int cruisersNumber = Convert.ToInt32(cruisersString);

            Console.Clear();
            Console.Write("Click ENTER to start: ");
            
            //restart game on ENTER, end game on any other key
            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                //new game
                var game = new Game(size)
                {
                    Ships = ShipCreator.CreateShips(cruisersNumber, battleshipsNumber, size)
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