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
                Console.Clear();
                Console.Write("Enter proper size of the map: ");
                sizeString = Console.ReadLine();
            }

            int size = Convert.ToInt32(sizeString);

            Console.Clear();
            Console.Write("Click ENTER to start: ");
            //restart game on ENTER, end game on any other key
            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                //new game
                var game = new Game(size)
                {
                    Ships = ShipCreator.CreateShips(2, 1, size)
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