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

            //restart game on ENTER, end game on any other key
            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                //new game
                var game = new Game {Ships = ShipCreator.CreateShips(2, 1)};
                
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
                ConsoleHelper.ShowYouWinScreen(); 
            }
        }
    }
}